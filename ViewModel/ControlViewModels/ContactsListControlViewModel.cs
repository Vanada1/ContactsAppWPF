﻿using System;
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
    public class ContactsListControlViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Selected contact
        /// </summary>
        private Contact _selectedContact;

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
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

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

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        public ContactsListControlViewModel(ObservableCollection<Contact> allContacts)
        {
            SearchedContacts = AllContacts = allContacts;
            Command = new Command();
        }

        /// <summary>
        /// Notifies about value change
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
