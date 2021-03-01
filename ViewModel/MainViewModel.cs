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
		private readonly Project _project;

        /// <summary>
        /// Контрол со списком контактов
        /// </summary>
        private ContactsListControlViewModel _contactsControlView;

        /// <summary>
        /// Контрол с контактами, у которых ДР
        /// </summary>
        private BirthdayControlViewModel _birthdayControlView;

        /// <summary>
        /// Модель элемента списка контактов
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
        /// Возвращает и устанавливает контрол с контактами, у которых ДР
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
                new Contact("TestName", "TestLastName", new PhoneNumber(78005553535), DateTime.Now, "dsa@g,mai.ds", "vsda"),
                new Contact("TestName", "TestLastName", new PhoneNumber(78995553535), DateTime.Now, "dsa@g,mai.ds", "vsda")
            };
            ContactsModel = new ContactsListControlViewModel(_project.Contacts);
            ContactsModel.SearchedStringChanged += OnSearchedStringChanged;
            BirthdayControlViewModel.CreatedViewModel += OnCreatedViewModel;
            BirthdayControlView = new BirthdayControlViewModel();
        }

        /// <summary>
        /// Обработчик события для изменения строки поиска
        /// </summary>
        /// <param name="sender"><see cref="ContactsListControlViewModel"/></param>
        /// <param name="e"></param>
        private void OnSearchedStringChanged(object sender, EventArgs e)
        {
            var model = (ContactsListControlViewModel) sender;
            if(model == null) return;

            model.SearchedContacts = _project.SearchContacts(model.SearchingString);
        }

        private void OnCreatedViewModel(object sender, EventArgs e)
        {
            var model = (BirthdayControlViewModel)sender;
            if (model == null) return;

            model.SearchedContacts = _project.FindBirthdayContacts(DateTime.Now);
        }
    }
}
