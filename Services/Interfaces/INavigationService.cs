using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListTracker.ViewModels;

namespace ToDoListTracker.Services.Interfaces;

public interface INavigationService
{
        Task NavigateToAsync<TViewModel>(bool animate = true) where TViewModel : BaseViewModel;
        Task NavigateBackAsync(bool animate = true);
}