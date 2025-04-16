using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ToDoListTracker.Models;
using ToDoListTracker.Services.Interfaces;

namespace ToDoListTracker.Services;

public class ToDoListService : IToDoListService
{
    private readonly List<ToDoList> _toDoLists = new();
    private ToDoList? _activeList;

    public List<ToDoList> GetAllLists() => _toDoLists;

    public ToDoList? GetActiveList() => _activeList ?? null;

    public ToDoList CreateList(string name, List<ToDoItem>? list = null)
    {
        list ??= new();
    
        // Generate a unique name if the name already exists
        string uniqueName = GenerateUniqueName(name);

        var newList = new ToDoList
        {
            Id = Guid.NewGuid(),
            Name = uniqueName,
            Items = new ObservableCollection<ToDoItem>(list)
        };

        _toDoLists.Add(newList);
        _activeList = newList;

        return newList;
    }

    private string GenerateUniqueName(string baseName)
    {
        int counter = 1;
        string uniqueName = baseName;

        // Check if the name already exists in the list
        while (_toDoLists.Any(list => list.Name.Equals(uniqueName, StringComparison.OrdinalIgnoreCase)))
        {
            uniqueName = $"{baseName} ({counter})";
            counter++;
        }

        return uniqueName;
    }


    public ToDoList UpdateList(Guid id, string newName, List<ToDoItem>? items = null)
    {
        var list = _toDoLists.FirstOrDefault(l => l.Id == id) ?? new();
        var observableItemsCollection = new ObservableCollection<ToDoItem>(items);
        list.Name = newName;
        list.Items = observableItemsCollection;

        return list;
    }

    public List<ToDoList> DeleteList(Guid id)
    {
        var list = _toDoLists.FirstOrDefault(l => l.Id == id);
        if (list != null)
        {
            _toDoLists.Remove(list);
            _activeList = null;
        }

        return _toDoLists;
    }

    public void SetActiveList(Guid id)
    {
        _activeList = id == Guid.Empty ? null : _toDoLists.FirstOrDefault(l => l.Id == id);
    }
}

