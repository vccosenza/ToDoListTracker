using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoListTracker.Models;
using ToDoListTracker.Services.Interfaces;

namespace ToDoListTracker.ViewModels;

public partial class HomeViewModel: BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IToDoListService _toDoListService;

    [ObservableProperty]
    private ObservableCollection<ToDoListGroup> _groupedToDoLists;

    public HomeViewModel(INavigationService navigationService, IToDoListService toDoListService)
    {
        _navigationService = navigationService;
        _toDoListService = toDoListService;
        
        // Load initial lists
        var toDoLists = _toDoListService.GetAllLists();

        RefreshGroupedLists(toDoLists);
    }


    [RelayCommand]
    private void LoadLists()
    {
        _toDoListService.SetActiveList(Guid.Empty);

        var toDoLists = _toDoListService.GetAllLists();
        RefreshGroupedLists(toDoLists);
    }

    [RelayCommand]
    private async Task OpenToDoList(ToDoList? list = null)
    {
        if (list != null)
        {
            _toDoListService.SetActiveList(list.Id);
        }

        await _navigationService.NavigateToAsync<ActiveToDoListViewModel>();
    }

    [RelayCommand]
    private void DeleteToDoList(ToDoList list)
    {
        var updatedList = _toDoListService.DeleteList(list.Id);
        RefreshGroupedLists(updatedList);
    }
    
    private void RefreshGroupedLists(List<ToDoList> allLists)
    {
        if (allLists.Count == 0)
        {
            GroupedToDoLists = new ObservableCollection<ToDoListGroup>();
        }
        else
        {
            // Group lists into active and completed
            var activeLists = allLists
                .Where(list => !list.Items.Any() || list.Items.Any(item => !item.IsCompleted))
                .ToList();

            var completedLists = allLists
                .Where(list => list.Items.All(item => item.IsCompleted) && list.Items.Count > 0)
                .ToList();

            var groups = new List<ToDoListGroup>();

            // Add "Active Lists" only if it has items
            if (activeLists.Count > 0)
            {
                groups.Add(new ToDoListGroup("Active Lists", activeLists));
            }

            // Add "Completed Lists" only if it has items
            if (completedLists.Count > 0)
            {
                groups.Add(new ToDoListGroup("Completed Lists", completedLists));
            }

            GroupedToDoLists = new ObservableCollection<ToDoListGroup>(groups);
        }

    }
}

