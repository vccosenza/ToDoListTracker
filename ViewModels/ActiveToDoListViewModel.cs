using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoListTracker.Models;
using ToDoListTracker.Services.Interfaces;

namespace ToDoListTracker.ViewModels;

public partial class ActiveToDoListViewModel : BaseViewModel
{
    private readonly IToDoListService _toDoListService;

    [ObservableProperty]
    private string _listName;

    [ObservableProperty]
    private ObservableCollection<ToDoItem> _toDoItems;

    [ObservableProperty]
    private ToDoList? _activeList;

    [ObservableProperty]
    private bool _isNewList;

    public ActiveToDoListViewModel(IToDoListService toDoListService)
    {
        _toDoListService = toDoListService;

        ActiveList = _toDoListService.GetActiveList();
        if (ActiveList is null)
        {
            IsNewList = true;
            ToDoItems = new ObservableCollection<ToDoItem>();
        }
        else
        {
            ListName = ActiveList.Name;
            ToDoItems = ActiveList.Items;
        }
    }

    [RelayCommand]
    private void AddToDoItem()
    {
        // Add a new empty task to the list
        var newTask = new ToDoItem { Name = "New Task", IsCompleted = false };
        ToDoItems.Add(newTask);

        // Trigger update in the service
        UpdateList();
    }

    [RelayCommand]
    private void CompleteToDoItem(ToDoItem item)
    {
        // Update the task's completion status
        item.IsCompleted = !item.IsCompleted;

        // Trigger update in the service
        UpdateList();
    }
    
    [RelayCommand]
    private void UpdateName()
    {
        UpdateList();
    }
    
    [RelayCommand]
    private void DeleteToDoItemTask(ToDoItem toDoItem)
    {
        ToDoItems.Remove(toDoItem);
        UpdateList();
    }
    
    private void UpdateList()
    {
        if (ActiveList is null)
        {
            // Create the list in the service
            ActiveList = _toDoListService.CreateList(ListName);
        }
        else
        {
            // Update the existing list
            ActiveList = _toDoListService.UpdateList(ActiveList.Id, ListName, ToDoItems.ToList());
        }
    }
}

