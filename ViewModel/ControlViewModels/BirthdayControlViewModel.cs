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

namespace ViewModel.ControlViewModels
{
	public class BirthdayControlViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Все имена контактов, у которых ДР
		/// </summary>
		private string _birthdayNames;

		private int _visibility = 0;

		/// <summary>
		/// События, которые выполняется при создании экземпляра класса
		/// </summary>
		public static event EventHandler CreatedViewModel;

		/// <summary>
		/// Возвращает и устанавливает найденные контакты, у которых сегодня ДР
		/// </summary>
		public ObservableCollection<Contact> SearchedContacts { get; set; }

        /// <summary>
        /// Видимо ли окно
        /// </summary>
        public int Visibility
        {
            get=>_visibility;
            set
            {
                _visibility = value;
				OnPropertyChanged(nameof(Visibility));
            }
        }

		/// <summary>
		/// Возвращает и устанавливает имена найденных контакты, у которых сегодня ДР
		/// </summary>
		public string  BirthdayNames
		{
			get => _birthdayNames;
			set
			{
				_birthdayNames = value;
				OnPropertyChanged(nameof(BirthdayNames));
			}
		}

        public BirthdayControlViewModel()
		{
			CreatedViewModel?.Invoke(this, EventArgs.Empty);
			BirthdayNames = GetBirthdayNames();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Делает строку имен и фамилий контактов, у которых сегодня ДР
		/// </summary>
		/// <returns>
		///		Строку имен и фамилий контактов, у которых сегодня ДР. 
		///		Если контактов нет, то контрол не показывается
		/// </returns>
		private string GetBirthdayNames()
		{
			if (SearchedContacts == null || SearchedContacts.Count == 0)
			{
                Visibility = 1;
				return string.Empty;
			}

			var contactsName = string.Empty;
			for (var i = 0; i < SearchedContacts.Count - 1; i++)
			{
				var contact = SearchedContacts[i];
				contactsName += contact.FirstName + " " + contact.LastName + ", ";
			}

			contactsName += SearchedContacts.Last().FirstName + " " + SearchedContacts.Last().LastName;
			return contactsName;
		}
	}
}
