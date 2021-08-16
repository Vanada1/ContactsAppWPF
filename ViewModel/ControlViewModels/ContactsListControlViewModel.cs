using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ContactsApp;
using GalaSoft.MvvmLight;
using ViewModel.Services;

namespace ViewModel.ControlViewModels
{
    /// <summary>
    /// ViewModel class for contact list
    /// </summary>
    public class ContactsListControlViewModel : ViewModelBase
    {
        /// <summary>
        /// All program data
        /// </summary>
	    private readonly Project _project;

        /// <summary>
        /// Selected contact
        /// </summary>
        private readonly PersonDataControlViewModel _selectedContact = new PersonDataControlViewModel(true, null);

        /// <summary>
        /// Search line
        /// </summary>
        private string _searchingString;

        /// <summary>
        /// All found contacts
        /// </summary>
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
            set => Set(ref _searchedContacts, value);

        }
        
        /// <summary>
        /// Returns and sets the selected contact
        /// </summary>
        public Contact SelectedContact
        {
	        get => _selectedContact.Contact;
	        set
	        {
		        _selectedContact.Contact = value;
		        RaisePropertyChanged(nameof(SelectedContact));
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
		        Set(ref _searchingString, value);
		        SearchedContacts = _project.SearchContacts(SearchingString);
            }
        }

        /// <summary>
        /// Returns the commands used by buttons
        /// </summary>
        public Command Command { get; }

        
        public ContactsListControlViewModel(Project project, 
            IWindowService windowService, IMessageBoxService messageBoxService)
        {
	        _project = project;
	        AllContacts = project.Contacts;
            SearchedContacts = AllContacts;
            Command = new Command(windowService, messageBoxService);
            SearchingString = string.Empty;
        }
    }
}
