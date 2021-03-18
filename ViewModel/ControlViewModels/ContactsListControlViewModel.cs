using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Annotations;
using ViewModel.Commands;

namespace ViewModel.ControlViewModels
{
    /// <summary>
    /// ViewModel class for contact list
    /// </summary>
    public class ContactsListControlViewModel : ViewModelBase
    {
        /// <summary>
        /// Selected contact
        /// </summary>
        private readonly PersonDataControlViewModel _selectedContact = new PersonDataControlViewModel(true, null);

        /// <summary>
        /// Search line
        /// </summary>
        private string _searchingString;

        private ObservableCollection<Contact> _searchedContacts;

        /// <summary>
        /// Returns all contacts
        /// </summary>
        public ObservableCollection<Contact> AllContacts { get; }

        /// <summary>
        /// Returns and sets all found contacts
        /// </summary>
        public ObservableCollection<Contact> SearchedContacts 
        { 
            get => _searchedContacts;
            set
            {
                _searchedContacts = value;
                OnPropertyChanged(nameof(SearchedContacts));
            }

        }

        /// <summary>
        /// Returns the commands used by buttons
        /// </summary>
        public Command Command { get; }

        /// <summary>
        /// Returns and sets the selected contact
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact.Contact;
            set
            {
                _selectedContact.Contact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public PersonDataControlViewModel PersonDataControlViewModel => _selectedContact;

        /// <summary>
        /// Returns and sets the search string
        /// </summary>
        public string SearchingString
        {
            get => _searchingString;
            set
            {
                _searchingString = value;
                OnPropertyChanged(nameof(SearchingString));
                SearchedStringChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event that occurs when the search string changes
        /// </summary>
        public event EventHandler SearchedStringChanged;
        
        public ContactsListControlViewModel(ObservableCollection<Contact> allContacts)
        {
            SearchedContacts = AllContacts = allContacts;
            Command = new Command();
        }
    }
}
