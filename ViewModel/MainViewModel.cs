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
using ViewModel.ControlViewModels;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for window MainWindow
    /// </summary>
	public class MainViewModel : ViewModelBase
	{
        /// <summary>
        /// Application data
        /// </summary>
        private readonly Project _project;

        /// <summary>
        /// Control with contact list
        /// </summary>
        private ContactsListControlViewModel _contactsListControlViewModel;

        /// <summary>
        /// Control with contacts who have a birthday
        /// </summary>
        private BirthdayControlViewModel _birthdayControlViewModel;

        /// <summary>
        /// PersonDataControlViewModel list item model
        /// </summary>
        public ContactsListControlViewModel ContactsListControlViewModel
        {
            get=>_contactsListControlViewModel;
            set
            {
                _contactsListControlViewModel = value;
				OnPropertyChanged(nameof(ContactsListControlViewModel));
            }
        }

        /// <summary>
        /// Revives and establishes control with contacts who have birthday
        /// </summary>
        public BirthdayControlViewModel BirthdayControlViewModel
        {
            get => _birthdayControlViewModel;
            set
            {
                _birthdayControlViewModel = value;
                OnPropertyChanged(nameof(BirthdayControlViewModel));
            }
        }
        
        public MainViewModel()
		{
			_project = ProjectManager.ReadProject();
            ContactsListControlViewModel = new ContactsListControlViewModel(_project.Contacts);
            ContactsListControlViewModel.SearchedStringChanged += OnSearchedStringChanged;
            BirthdayControlViewModel.CreatedViewModel += OnCreatedViewModel;
            BirthdayControlViewModel = new BirthdayControlViewModel();
        }

        /// <summary>
        /// Save application data
        /// </summary>
        public void Save()
        {
            ProjectManager.SaveProject(_project);
        }

        /// <summary>
        /// Event handler for changing the search string
        /// </summary>
        /// <param name="sender"><see cref="ControlViewModels.ContactsListControlViewModel"/></param>
        /// <param name="e"></param>
        private void OnSearchedStringChanged(object sender, EventArgs e)
        {
            var model = (ContactsListControlViewModel) sender;
            if(model == null) return;

            model.SearchedContacts = _project.SearchContacts(model.SearchingString);
        }

        /// <summary>
        /// Processor creating a ViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreatedViewModel(object sender, EventArgs e)
        {
            var model = (BirthdayControlViewModel)sender;
            if (model == null) return;

            model.SearchedContacts = _project.FindBirthdayContacts(DateTime.Now);
        }
    }
}
