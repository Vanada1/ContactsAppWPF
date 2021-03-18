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
	public class PhoneNumber:NotifyDataErrorInfoViewModelBase, ICloneable
	{
        /// <summary>
        /// Number phone
        /// </summary>
        private string _number;

        /// <summary>
		/// Sets and returns <see cref="Number"> values 
		/// </summary>
		public string Number
        { 
            get => _number;
            set
            {
                _number = value;
                Validation(this, nameof(Number));
                OnPropertyChanged(nameof(Number));
                OnPropertyChanged(nameof(HasErrors));
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
    }
}
