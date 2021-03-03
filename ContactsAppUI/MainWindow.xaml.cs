using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactsApp;
using ViewModel;
using ViewModel.Commands;

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
            var listBoxControl = mainVM.ContactsModel;
            MenuControl.AboutButton.Command = new RelayCommand(o => (new AboutWindow()).ShowDialog());
            MenuControl.ExitButton.Command = new RelayCommand(o =>
            {
                mainVM.Save();
                Close();
            });
            MenuControl.RemoveButton.Command = listBoxControl.Command.RemoveContactCommand;
            MenuControl.AddButton.Command = listBoxControl.Command.AddContactCommand = new RelayCommand(o =>
            {
                var window = new AddEditContactWindow();
                if (window.ShowDialog() != true) return;

                listBoxControl.AllContacts.Add(window.Model.Contact);
                mainVM.Save();
            });

            MenuControl.EditButton.Command = listBoxControl.Command.EditContactCommand= new RelayCommand(o =>
            {
                if (listBoxControl.SelectedContact == null)
                {
                    return;
                }

                var window = new AddEditContactWindow((Contact)listBoxControl.SelectedContact.Clone());
                var itemIndex = listBoxControl.AllContacts.IndexOf(listBoxControl.SelectedContact);
                if (window.ShowDialog() != true) return;

                listBoxControl.AllContacts[itemIndex] = window.Model.Contact;
                mainVM.Save();
            });

            DataContext = mainVM;
        }
    }
}
