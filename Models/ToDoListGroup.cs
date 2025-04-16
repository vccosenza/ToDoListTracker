using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToDoListTracker.Models;

public class ToDoListGroup : ObservableCollection<ToDoList>
{
    public string Name { get; }
    
    public ToDoListGroup(string name, IEnumerable<ToDoList> lists) : base(lists)
    {
        Name = name;
    }
}