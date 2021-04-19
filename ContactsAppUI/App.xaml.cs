using System;
using System.IO;
using System.Windows;
using ContactsAppUI.Services;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViewModel;
using ViewModel.Services;

namespace ContactsAppUI
{
	/// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
	    public IServiceProvider ServiceProvider { get; private set; }

		public IConfiguration Configuration { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
	    {
		    base.OnStartup(e);
		    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

		    Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();
			ConfigureService(serviceCollection);

			ServiceProvider = serviceCollection.BuildServiceProvider();

			var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
			((MainViewModel) mainWindow.DataContext).MenuControlViewModel.ExitCommand =
				new RelayCommand(() => mainWindow.Close());
			mainWindow.ShowDialog();
	    }

		private void ConfigureService(ServiceCollection service)
		{
			service.AddScoped<IWindowService, ContactWindowService>();
			service.AddScoped<IMessageBoxService, MessageBoxService>();
			service.AddScoped<IInformationWindow, AboutWindowService>();
			service.AddTransient<MainViewModel>();
			service.AddTransient<MainWindow>(provider => new MainWindow
				{DataContext = provider.GetService<MainViewModel>()});
		}
    }
}
