using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoListTracker.Models;

public partial class ToDoItem : ObservableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [ObservableProperty] private bool _isCompleted;

    [ObservableProperty] private string _name = string.Empty;
    
    [ObservableProperty] private DateTime? _dueDate;
}