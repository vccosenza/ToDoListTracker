using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ToDoListTracker.Services;
using ToDoListTracker.Services.Interfaces;
using ToDoListTracker.Views;
using ToDoListTracker.ViewModels;

namespace ToDoListTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services
			.AddTransient<ActiveToDoListPage>()
			.AddTransient<ActiveToDoListViewModel>()
			.AddTransient<HomePage>()
			.AddTransient<HomeViewModel>()
			.AddTransient<AboutPage>()
			.AddTransient<AboutViewModel>()
			.AddSingleton<INavigationService, NavigationService>()
			.AddSingleton<IToDoListService, ToDoListService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
