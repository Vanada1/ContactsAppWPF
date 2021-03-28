using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ContactsAppUI.Services;
using ViewModel;
using ViewModel.Commands;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
	    protected override void OnStartup(StartupEventArgs e)
	    {
		    base.OnStartup(e);
		    var mainVm =
			    new MainViewModel(new ContactWindowService(), new MessageBoxService(), new AboutWindowService());
			var mainWindow = new MainWindow{DataContext = mainVm};
			mainVm.MenuControlViewModel.ExitCommand = new RelayCommand(_ => mainWindow.Close());
			mainWindow.ShowDialog();
	    }
    }
}
