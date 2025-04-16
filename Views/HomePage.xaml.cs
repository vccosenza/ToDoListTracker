using Microsoft.Maui.Controls;
using ToDoListTracker.ViewModels;

namespace ToDoListTracker.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}