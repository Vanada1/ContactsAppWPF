using System.ComponentModel;
using System.Windows;
using ContactsApp;
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

            var mainVM = new MainViewModel();
            var listBoxControl = mainVM.ContactsListControlViewModel;
            var command = listBoxControl.Command;
            MenuControl.AboutButton.Command = new RelayCommand(o => (new AboutWindow()).ShowDialog());
            MenuControl.ExitButton.Command = new RelayCommand(o =>
            {
                mainVM.Save();
                Close();
            });
            MenuControl.RemoveButton.Command = command.RemoveContactCommand;
            command.AddContactCommand = new RelayCommand(o =>
            {
                var window = new AddEditContactWindow();
                if (window.ShowDialog() != true) return;

                listBoxControl.AllContacts.Add(window.Model.PersonDataControlViewModel.Contact);
                mainVM.Save();
            });
            MenuControl.AddButton.Command = command.AddContactCommand;

            command.EditContactCommand = new RelayCommand(o =>
            {
                if (listBoxControl.SelectedContact == null)
                {
                    MessageBox.Show("Select Item", "Alert",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var window = new AddEditContactWindow((Contact) listBoxControl.SelectedContact.Clone());
                var itemIndex = listBoxControl.AllContacts.IndexOf(listBoxControl.SelectedContact);
                if (window.ShowDialog() != true) return;

                listBoxControl.SelectedContact =
                    listBoxControl.AllContacts[itemIndex] = window.Model.PersonDataControlViewModel.Contact;
                mainVM.Save();
            });
           MenuControl.EditButton.Command = command.EditContactCommand;

            command.RemoveContactCommand = new RelayCommand(o =>
            {
                if (!(o is ContactsListControlViewModel model))
                {
                    MessageBox.Show("Inappropriate data type");
                    return;
                }

                if (model.SelectedContact == null)
                {
                    MessageBox.Show("Item not selected","Alert",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                model.AllContacts.Remove(model.SelectedContact);
                mainVM.Save();
            });

            DataContext = mainVM;
        }

        public void ClosingWindow(object sender, CancelEventArgs e)
        {
            var dataContext = (MainViewModel) DataContext;
            dataContext.Save();
        }
    }
}
