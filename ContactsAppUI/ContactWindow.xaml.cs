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
	    public ContactWindow(object contact)
        {
            InitializeComponent();
            DataContext = contact;
        }

        public ContactWindow() {}
    }
}
