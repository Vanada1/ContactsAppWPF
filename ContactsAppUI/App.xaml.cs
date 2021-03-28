using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ContactsAppUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViewModel;
using ViewModel.Commands;
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
				new RelayCommand(_ => mainWindow.Close());
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
