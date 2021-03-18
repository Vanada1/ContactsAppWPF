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

            var mainVM = new MainViewModel(new AddEditWindowService(), new MessageBoxService());
            var listBoxControl = mainVM.ContactsListControlViewModel;
            var command = listBoxControl.Command;
            MenuControl.AboutButton.Command = new RelayCommand(o => (new AboutWindow()).ShowDialog());
            MenuControl.ExitButton.Command = new RelayCommand(o =>
            {
                mainVM.Save();
                Close();
            });

            MenuControl.AddButton.Command = command.AddContactCommand;
            MenuControl.EditButton.Command = command.EditContactCommand;
            MenuControl.RemoveButton.Command = command.RemoveContactCommand;

            DataContext = mainVM;
        }

        public void ClosingWindow(object sender, CancelEventArgs e)
        {
            var dataContext = (MainViewModel) DataContext;
            dataContext.Save();
        }
    }
}
