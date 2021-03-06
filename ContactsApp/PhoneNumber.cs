using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp.Annotations;

namespace ContactsApp
{
	/// <summary>
	/// Class <see cref="PhoneNumber"> contains the telephone number of the person
	/// </summary>
	public class PhoneNumber:IDataErrorInfo, INotifyPropertyChanged
	{
        /// <summary>
        /// Number phone
        /// </summary>
        private string _number;

        /// <summary>
        /// Max count of symbols for <see cref="Contact.PhoneNumber"/>
        /// </summary>
        public const int MaxPhoneNumberSymbolsCount = 11;

        /// <summary>
		/// Sets and returns <see cref="Number"> values 
		/// </summary>
		public string Number
        { 
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        /// <summary>
		/// <see cref="PhoneNumber"/> constructor
		/// </summary>
		/// <param name="number">
		/// Gets a phone number
		/// </param>
		public PhoneNumber(string number)
		{
			this.Number = number;
		}

        public PhoneNumber()
        {

        }

        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;
                try
                {
                    StringValidator.AssertPhoneNumber(Number, MaxPhoneNumberSymbolsCount);
                }
                catch (ArgumentException e)
                {
                    error = e.Message;
                }

                return error;
            }
        }

        public string Error { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
