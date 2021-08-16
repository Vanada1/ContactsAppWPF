using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace ContactsApp
{
    /// <summary>
    /// Base class for VM with INotifyDataErrorInfo
    /// </summary>
    public abstract class NotifyDataErrorInfoViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        /// <summary>
        /// Max count of letters
        /// </summary>
        public const int MaxLettersCount = 50;

        /// <summary>
        /// Max count of symbols for <see cref="Contact.PhoneNumber"/>
        /// </summary>
        public const int MaxPhoneNumberSymbolsCount = 11;

        /// <summary>
        /// Contains all <see cref="Contact"/> errors
        /// </summary>
        private static readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        /// <inheritdoc />
        public virtual bool HasErrors => _errors.Any();

        /// <inheritdoc />
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <inheritdoc />
        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
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
            _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// Check validation
        /// </summary>
        /// <param name="value">Property value</param>
        /// <param name="propertyName"></param>
        protected void Validation(object value, string propertyName)
        {
            ClearErrors(propertyName);
            try
            {
                switch (value)
                {
                    case string stringValue:
                    {
                        StringValidator.AssertStringLength(stringValue, MaxLettersCount, propertyName);
                        break;
                    }
                    case DateTime dateTimeValue:
                    {
                        DateValidator.AssertDate(dateTimeValue);
                        break;
                    }
                    case PhoneNumber phoneNumber:
                    {
                        StringValidator.AssertPhoneNumber(phoneNumber.Number, MaxPhoneNumberSymbolsCount);
                        break;
                    }
                }
            }
            catch (ArgumentException e)
            {
                AddError(propertyName, e.Message);
            }
        }
    }
}
