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
	public class MainViewModel : INotifyPropertyChanged
	{
        /// <summary>
        /// Application data
        /// </summary>
        private readonly Project _project;

        /// <summary>
        /// Control with contact list
        /// </summary>
        private ContactsListControlViewModel _contactsControlView;

        /// <summary>
        /// Control with contacts who have a birthday
        /// </summary>
        private BirthdayControlViewModel _birthdayControlView;

        /// <summary>
        /// Contact list item model
        /// </summary>
        public ContactsListControlViewModel ContactsModel
        {
            get=>_contactsControlView;
            set
            {
                _contactsControlView = value;
				OnPropertyChanged(nameof(ContactsModel));
            }
        }

        /// <summary>
        /// Revives and establishes control with contacts who have birthday
        /// </summary>
        public BirthdayControlViewModel BirthdayControlView
        {
            get => _birthdayControlView;
            set
            {
                _birthdayControlView = value;
                OnPropertyChanged(nameof(BirthdayControlView));
            }
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
		{
			_project = ProjectManager.ReadProject();
            ContactsModel = new ContactsListControlViewModel(_project.Contacts);
            ContactsModel.SearchedStringChanged += OnSearchedStringChanged;
            BirthdayControlViewModel.CreatedViewModel += OnCreatedViewModel;
            BirthdayControlView = new BirthdayControlViewModel();
        }

        /// <summary>
        /// Save application data
        /// </summary>
        public void Save()
        {
            ProjectManager.SaveProject(_project);
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

        /// <summary>
        /// Event handler for changing the search string
        /// </summary>
        /// <param name="sender"><see cref="ContactsListControlViewModel"/></param>
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
