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
using ViewModel.ControlViewModels;
using ViewModel.Services;

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
        /// Menu control
        /// </summary>
        private MenuControlViewModel _menuControlViewModel;

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

        /// <summary>
        /// Returns and sets Menu control
        /// </summary>
        public MenuControlViewModel MenuControlViewModel
        {
            get => _menuControlViewModel;
            set
            {
                _menuControlViewModel = value;
                OnPropertyChanged(nameof(MenuControlViewModel));
            }
        }

        public MainViewModel(IWindowService windowService, IMessageBoxService messageBoxService,
            IWindowService aboutService)
		{
			_project = ProjectManager.ReadProject();
            ContactsListControlViewModel = new ContactsListControlViewModel(_project.Contacts, 
                windowService, messageBoxService);
            ContactsListControlViewModel.SearchedStringChanged += OnSearchedStringChanged;
            BirthdayControlViewModel = new BirthdayControlViewModel(_project.FindBirthdayContacts(DateTime.Now));
            MenuControlViewModel = new MenuControlViewModel(ContactsListControlViewModel, windowService,
	            messageBoxService, aboutService);
        }

        /// <summary>
        /// Save application data
        /// </summary>
        public void Save()
        {
            ProjectManager.SaveProject(_project);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            Save();
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
    }
}
