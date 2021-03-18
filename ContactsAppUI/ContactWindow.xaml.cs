using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContactsApp;
using ViewModel;
using ViewModel.Commands;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        /// <summary>
        /// VM окна
        /// </summary>
        public ContactWindowViewModel Model { get; set; }

        public ContactWindow(Contact contact)
        {
            InitializeComponent();
            Model = new ContactWindowViewModel(contact)
            {
                OkCommand = new RelayCommand(o =>
                {
                    if(!Model.PersonDataControlViewModel.Contact.HasErrors)
                    {
                        DialogResult = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Some fields are wrong!\nCheck your entries", "Error", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }),
                CancelCommand = new RelayCommand(o =>
                {
                    DialogResult = false;
                    Close();
                })
            };
            DataContext = Model;
        }

        public ContactWindow() : this(new Contact(string.Empty, string.Empty, new PhoneNumber(), 
            DateTime.Now, string.Empty, string.Empty))
        { }
    }
}
