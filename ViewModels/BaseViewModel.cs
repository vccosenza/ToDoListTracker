using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoListTracker.ViewModels;

/// <summary>
/// For the sake of this simple application, we could likely just use ObservableObject as our base
/// Only reason to give a base in this case is to make sure we are strict with the navigation service types
/// Note that nothing redundant would ever be implemented in a full scale application
/// Things to add - initalize logic for navigation parameters, IsBusy if loading is apart of app, dispose logic if needed
/// If not using community toolkit - add property change logic to this class for data binding
/// </summary>
public abstract class BaseViewModel : ObservableObject
{
}