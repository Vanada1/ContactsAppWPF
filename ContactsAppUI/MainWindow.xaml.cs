using System.ComponentModel;
using System.Windows;
using ContactsApp;
using ContactsAppUI.Services;
using ViewModel;
using ViewModel.Commands;
using ViewModel.ControlViewModels;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainVm =
                new MainViewModel(new ContactWindowService(), new MessageBoxService(), new AboutWindowService())
                {
                    MenuControlViewModel = {ExitCommand = new RelayCommand(o => Close())}
                };
            DataContext = mainVm;
        }

        public void ClosingWindow(object sender, CancelEventArgs e)
        {
            var dataContext = (MainViewModel) DataContext;
            dataContext.Save();
        }
    }
}
