using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ContactsApp
{
    /// <summary>
    /// The <see cref="Contact"> class contains information about the contact: 
    /// <see cref="FirstName">, <see cref="LastName">, <see cref="PhoneNumber">,
    /// <see cref="Birthday">, <see cref="Email">, <see cref="VkId">
    /// </summary>
    public class Contact : ICloneable, INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Max count of letters for <see cref="FirstName"/>, 
        /// <see cref="LastName"/>, <see cref="Email"/>
        /// </summary>
        public const int MaxLettersCount = 50;

        /// <summary>
        /// Max count of letters for <see cref="VkId"/>
        /// </summary>
        public const int MaxVkLettersCount = 15;

        /// <summary>
        /// Contact <see cref="FirstName"/>
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Contact <see cref="LastName"/>
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Contact <see cref="Birthday"/>
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// Contact <see cref="Email"/>
        /// </summary>
        private string _email;

        /// <summary>
        /// Contact <see cref="VkId"/>
        /// </summary>
        private string _vkId;

        /// <summary>
        /// Contains all <see cref="Contact"/> errors
        /// </summary>
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        /// <summary>
        /// Sets and returns <see cref="FirstName"> values 
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                Validation(value, nameof(FirstName));
                _firstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                OnPropertyChanged(nameof(FirstName));
            }

        }

        /// <summary>
        /// Sets and returns <see cref="LastName"> values
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                Validation(value, nameof(LastName));
                _lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Sets and returns <see cref="Email"> values 
        /// </summary>
        public string Email
        {
            get => this._email;
            set
            {
                Validation(value, nameof(Email));
                _email = value;
                OnPropertyChanged(nameof(Email));
            }

        }

        /// <summary>
        /// Sets and returns <see cref="PhoneNumber"> values 
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Sets and returns <see cref="VkId"> values 
        /// </summary>
        public string VkId
        {
            get => _vkId;
            set
            {
                Validation(value, nameof(VkId));
                _vkId = value;
                OnPropertyChanged(nameof(VkId));
            }

        }

        /// <summary>
        /// Sets and returns <see cref="Birthday"> values 
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                Validation(value, nameof(Birthday));
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        /// <inheritdoc />
        public bool HasErrors => _errors.Any() || PhoneNumber.HasErrors;

        /// <inheritdoc />
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// <see cref="Contact"> object constructor
        /// </summary>
        /// <param name="lasrName"><see cref="LastName"></param>
        /// <param name="firstName"><see cref="FirstName"/></param>
        /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
        /// <param name="birthday"><see cref="Birthday"/></param>
        /// <param name="email"><see cref="Email"/></param>
        /// <param name="vkId"><see cref="VkId"/></param>
        public Contact(string firstName, string lasrName,
            PhoneNumber phoneNumber, DateTime birthday,
            string email, string vkId)
        {
            LastName = lasrName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Email = email;
            VkId = vkId;
        }

        public Contact() : this(string.Empty, string.Empty,
            new PhoneNumber(), DateTime.Now, string.Empty, string.Empty)
        {
        }

        /// <inheritdoc />
        public object Clone()
        {
            return new Contact(FirstName, LastName,
                (PhoneNumber)PhoneNumber.Clone(),
                Birthday, Email, VkId);
        }

        /// <inheritdoc />
        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        /// <summary>
        /// Notifies about value change
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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
        private void Validation(object value, string propertyName)
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
                }
            }
            catch (ArgumentException e)
            {
                AddError(propertyName, e.Message);
            }
        }
    }
}