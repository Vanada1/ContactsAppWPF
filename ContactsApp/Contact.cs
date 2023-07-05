using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// The <see cref="Contact"> class contains information about the contact: 
    /// <see cref="FirstName">, <see cref="LastName">, <see cref="PhoneNumber">,
    /// <see cref="Birthday">, <see cref="Email">, <see cref="VkId">
    /// </summary>
    public class Contact : NotifyDataErrorInfoViewModelBase, ICloneable
    {
        /// <summary>
        /// Contact <see cref="FirstName"/>
        /// </summary>
        private string _firstName;

        /// <summary>
        /// FirstName state
        /// </summary>
        private PropertyState _firstNameState = PropertyState.Initial;

        /// <summary>
        /// Contact <see cref="LastName"/>
        /// </summary>
        private string _lastName;

        /// <summary>
        /// LastName state
        /// </summary>
        private PropertyState _lastNameState = PropertyState.Initial;

        /// <summary>
        /// Contact <see cref="Birthday"/>
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// Birthday state
        /// </summary>
        private PropertyState _birthdayState = PropertyState.Initial;

        /// <summary>
        /// Contact <see cref="Email"/>
        /// </summary>
        private string _email;

        /// <summary>
        /// Email state
        /// </summary>
        private PropertyState _emailState = PropertyState.Initial;

        /// <summary>
        /// Contact <see cref="VkId"/>
        /// </summary>
        private string _vkId;

        /// <summary>
        /// VkId state
        /// </summary>
        private PropertyState _vkIdState = PropertyState.Initial;

        /// <summary>
        /// Sets and returns <see cref="FirstName"> values 
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
	            Set(ref _firstName, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value));

	            if (_firstNameState == PropertyState.Updated)
	            {
		            Validation(value, nameof(FirstName));
	            }

	            _firstNameState = PropertyState.Updated;
                RaisePropertyChanged(nameof(HasErrors));
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
	            Set(ref _lastName, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value));
	            if (_lastNameState == PropertyState.Updated)
	            {
		            Validation(value, nameof(LastName));
	            }

	            _lastNameState = PropertyState.Updated;
                RaisePropertyChanged(nameof(HasErrors));
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
	            Set(ref _email, value);
	            if (_emailState == PropertyState.Updated)
	            {
		            Validation(value, nameof(Email));
	            }

	            _emailState = PropertyState.Updated;
	            RaisePropertyChanged(nameof(HasErrors));
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
	            Set(ref _vkId, value);
	            if (_vkIdState == PropertyState.Updated)
	            {
		            Validation(value, nameof(VkId));
	            }

	            _vkIdState = PropertyState.Updated;
                RaisePropertyChanged(nameof(HasErrors));
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
	            Set(ref _birthday, value);
	            if (_birthdayState == PropertyState.Updated)
	            {
		            Validation(value, nameof(Birthday));
	            }

	            _birthdayState = PropertyState.Updated;
                RaisePropertyChanged(nameof(HasErrors));
            }
        }

        /// <inheritdoc />
        [JsonIgnore]
        public override bool HasErrors => base.HasErrors || PhoneNumber.HasErrors || !IsNotEmpty;

        [JsonIgnore]
        private bool IsNotEmpty => !string.IsNullOrWhiteSpace(FirstName) &&
                                   !string.IsNullOrWhiteSpace(LastName) &&
                                   !string.IsNullOrWhiteSpace(Email) &&
                                   !string.IsNullOrWhiteSpace(VkId) &&
                                   !string.IsNullOrWhiteSpace(PhoneNumber.Number);


        /// <summary>
        /// <see cref="Contact"> object constructor
        /// </summary>
        /// <param name="lastName"><see cref="LastName"></param>
        /// <param name="firstName"><see cref="FirstName"/></param>
        /// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
        /// <param name="birthday"><see cref="Birthday"/></param>
        /// <param name="email"><see cref="Email"/></param>
        /// <param name="vkId"><see cref="VkId"/></param>
        public Contact(string firstName, string lastName,
            PhoneNumber phoneNumber, DateTime birthday,
            string email, string vkId)
        {
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Email = email;
            VkId = vkId;
            PhoneNumber.PropertyChanged += OnPhoneNumberChanged;
        }

        private void OnPhoneNumberChanged(object sender, PropertyChangedEventArgs e)
        {
	        RaisePropertyChanged(nameof(PhoneNumber));
	        RaisePropertyChanged(nameof(HasErrors));
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
    }
}