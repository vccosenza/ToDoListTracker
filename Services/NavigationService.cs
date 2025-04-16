using ToDoListTracker.Services.Interfaces;
using ToDoListTracker.ViewModels;

namespace ToDoListTracker.Services;

public class NavigationService : INavigationService
{
    public async Task NavigateToAsync<TViewModel>(bool animate = true) where TViewModel : BaseViewModel
    {
        // Resolve the ViewModel type
        var viewModelType = typeof(TViewModel);

        // Map ViewModel to Route using Shell
        var pageRoute = ViewModelToRouteMapping(viewModelType);

        if (string.IsNullOrEmpty(pageRoute))
        {
            throw new InvalidOperationException($"No route found for ViewModel: {viewModelType.Name}");
        }
        
        // Navigate to the route
        await Shell.Current.GoToAsync(pageRoute, animate);
    }

    public async Task NavigateBackAsync(bool animate = true)
    {
        await Shell.Current.GoToAsync("..", animate);
    }

    private string ViewModelToRouteMapping(Type viewModelType)
    {
        // Get the ViewModel type name and remove "ViewModel"
        var viewModelName = viewModelType.Name;
        if (viewModelName.EndsWith("ViewModel"))
        {
            var routeName = viewModelName.Replace("ViewModel", "Page");
            return routeName;
        }

        throw new InvalidOperationException($"The ViewModel '{viewModelType.Name}' does not follow the naming convention: '*ViewModel'.");
    }

}
