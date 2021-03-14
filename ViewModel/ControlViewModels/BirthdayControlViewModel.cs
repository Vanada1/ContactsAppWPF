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
	/// <summary>
	/// ViewModel class for a list of people who have a birthday
	/// </summary>
	public class BirthdayControlViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// All names of contacts who have a birthday
		/// </summary>
		private string _birthdayNames;

        /// <summary>
        /// Is the window visible
        /// </summary>
		private int _visibility = 0;

		/// <summary>
		/// Events that are executed when the class is instantiated
		/// </summary>
		public static event EventHandler CreatedViewModel;

		/// <summary>
		/// Returns and installs found contacts who have DR
		/// </summary>
		public ObservableCollection<Contact> SearchedContacts { get; set; }

		/// <summary>
		/// Returns or sets the visibility of the window
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
		/// Returns and sets the names of found contacts who have birthday today
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

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

		public BirthdayControlViewModel()
		{
			CreatedViewModel?.Invoke(this, EventArgs.Empty);
			BirthdayNames = GetBirthdayNames();
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
		/// Makes a string of first and last names of contacts who have DR today
		/// </summary>
		/// <returns>
		///		A string of first and last names of contacts who have a birthday today.
        ///		If there are no contacts, then the control is not shown
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
