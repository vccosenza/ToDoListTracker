using Microsoft.Maui.Controls;
using ToDoListTracker.ViewModels;

namespace ToDoListTracker.Views;

public partial class ActiveToDoListPage : ContentPage
{
    public ActiveToDoListPage(ActiveToDoListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}