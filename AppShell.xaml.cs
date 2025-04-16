using Microsoft.Maui.Controls;
using ToDoListTracker.ViewModels;
using ToDoListTracker.Views;

namespace ToDoListTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(ActiveToDoListPage), typeof(ActiveToDoListPage));
		Routing.RegisterRoute(nameof(AboutPage), typeof(AboutViewModel));
	}
}
