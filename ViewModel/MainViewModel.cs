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
	public class MainViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Все данные приложения
		/// </summary>
		private Project _project;

        private ContactsListControlViewModel _contactsModel;

        /// <summary>
        /// Модель элемента списка контактов
        /// </summary>
        public ContactsListControlViewModel ContactsModel
        {
            get=>_contactsModel;
            set
            {
                _contactsModel = value;
				OnPropertyChanged(nameof(ContactsModel));
            }
        }

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public MainViewModel()
		{
			_project = ProjectManager.ReadProject();
            _project.Contacts = new ObservableCollection<Contact>
            {
                new Contact("Name", "Surname",
                    new PhoneNumber(78805553535), DateTime.Now, "maim@mai.ru", "123"),
                new Contact("Namasdasde", "Surnasdasdasame",
                    new PhoneNumber(78805553535), DateTime.Now, "maim@masdasdaai.ru", "asdasdasd")
            };
            ContactsModel = new ContactsListControlViewModel(_project.Contacts);
            ContactsModel.SearchedStringChanged += OnSearchedStringChanged;
		}

        private void OnSearchedStringChanged(object sender, EventArgs e)
        {
            var model = (ContactsListControlViewModel) sender;
            if(model == null) return;

            model.SearchedContacts = _project.SearchContacts(model.SearchingString);
        }

    }
}
