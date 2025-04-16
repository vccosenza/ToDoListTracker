using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoListTracker.ViewModels;

/// <summary>
/// For the sake of this simple application, we could likely just use ObservableObject as our base
/// This is just an example of some base behavior we may want
/// Note that nothing redundant would ever be implemented in a full scale application
/// </summary>
public abstract class BaseViewModel : ObservableObject
{
    /// <summary>
    /// Adds ability to pass parameters on navigation to and from pages
    /// </summary>
    public virtual Task InitializeAsync(Dictionary<string, object>? parameters) => Task.CompletedTask;
}