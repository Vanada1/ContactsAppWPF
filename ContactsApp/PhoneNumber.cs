using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ContactsApp.Annotations;

namespace ContactsApp
{
	/// <summary>
	/// Class <see cref="PhoneNumber"> contains the telephone number of the person
	/// </summary>
	public class PhoneNumber:INotifyDataErrorInfo, INotifyPropertyChanged, ICloneable
	{
        /// <summary>
        /// Number phone
        /// </summary>
        private string _number;

        /// <summary>
        /// Contains all <see cref="PhoneNumber"/> errors
        /// </summary>
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

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
                Validation(value, nameof(Number));
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        /// <inheritdoc />
        public bool HasErrors => _errors.Any();

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc />
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
		/// <see cref="PhoneNumber"/> constructor
		/// </summary>
		/// <param name="number">
		/// Gets a phone number
		/// </param>
		public PhoneNumber(string number)
		{
			Number = number;
		}

        public PhoneNumber()
        {
            Number = string.Empty;
        }

        /// <inheritdoc />
        public object Clone()
        {
            return new PhoneNumber(Number);
        }

        /// <inheritdoc />
        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
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
        /// Notifies about errors change
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Add error in the dictionary <see cref="_errors"/>
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="error"></param>
        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            if (_errors[propertyName].Contains(error)) return;
            _errors[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// Clear errors by key
        /// </summary>
        /// <param name="propertyName">key of dictionary</param>
        private void ClearErrors(string propertyName)
        {
            if (!_errors.ContainsKey(propertyName)) return;
            _errors[propertyName].Clear();
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// Check validation
        /// </summary>
        /// <param name="value">Property value</param>
        /// <param name="propertyName"></param>
        private void Validation(string value, string propertyName)
        {
            ClearErrors(propertyName);
            try
            {
                StringValidator.AssertPhoneNumber(value, MaxPhoneNumberSymbolsCount);
            }
            catch (ArgumentException e)
            {
                AddError(propertyName, e.Message);
            }
        }
    }
}
