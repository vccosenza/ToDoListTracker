using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoListTracker.Models;

namespace ToDoListTracker.Services.Interfaces;

public interface IToDoListService
{
    List<ToDoList> GetAllLists();
    ToDoList? GetActiveList();
    ToDoList CreateList(string name, List<ToDoItem>? list = null);
    ToDoList UpdateList(Guid id, string newName, List<ToDoItem>? items = null);
    List<ToDoList> DeleteList(Guid id);
    void SetActiveList(Guid id);
}

