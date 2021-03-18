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
    public class Contact : NotifyDataErrorInfoViewModelBase, ICloneable
    {
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
                OnPropertyChanged(nameof(HasErrors));
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
                OnPropertyChanged(nameof(HasErrors));
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
                OnPropertyChanged(nameof(HasErrors));
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
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <inheritdoc />
        public override bool HasErrors => base.HasErrors || PhoneNumber.HasErrors;

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
    }
}