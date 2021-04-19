using System.Windows;

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
