using System;
using System.Collections.ObjectModel;

namespace ToDoListTracker.Models;

public class ToDoList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ObservableCollection<ToDoItem> Items { get; set; } = new();
}