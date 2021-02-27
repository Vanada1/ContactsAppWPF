using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ContactsAppBL
{
	/// <summary>
	/// The <see cref="Contact"> class contains information about the contact: 
	/// <see cref="FirstName">, <see cref="LastName">, <see cref="PhoneNumber">,
	/// <see cref="Birthday">, <see cref="Email">, <see cref="VkId">
	/// </summary>
	public class Contact : ICloneable, INotifyPropertyChanged
	{
		/// <summary>
		/// Max count of letters for <see cref="FirstName"/>, 
		/// <see cref="LastName"/>, <see cref="Email"/>
		/// </summary>
        public const int MAXLETTERCOUNT = 50;

		/// <summary>
		/// Max count of letters for <see cref="VkId"/>
		/// </summary>
		public const int MAXVKLETTERCOUNT = 15;

		/// <summary>
		/// Contact <see cref="FirstName"/>
		/// </summary>
		private string _name;

		/// <summary>
		/// Contact <see cref="LastName"/>
		/// </summary>
		private string _surname;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(prop != null)
            {
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        /// Sets and returns <see cref="FirstName"> values 
        /// </summary>
        public string FirstName
		{
			get 
			{
				return _name; 
			}
			set
			{
				StringValidator.AssertStringLength(value,
					MAXLETTERCOUNT, nameof(FirstName)); 
				_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
				OnPropertyChanged(nameof(FirstName));
			}
			
		}

		/// <summary>
		/// Sets and returns <see cref="LastName"> values
		/// </summary>
		public string LastName
		{
			get 
			{ 
				return this._surname; 
			}
			set
			{
				StringValidator.AssertStringLength(value,
					MAXLETTERCOUNT, nameof(LastName));
				this._surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
				OnPropertyChanged(nameof(LastName));
			}
		}

	/// <summary>
	/// Sets and returns <see cref="Email"> values 
	/// </summary>
	public string Email
		{
			get 
			{ 
				return this._email;
			}
			set
			{
				StringValidator.AssertStringLength(value,
					MAXLETTERCOUNT, nameof(Email));
				this._email = value;
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
			get
			{ 
				return this._vkId;
			}
			set
			{
				StringValidator.AssertStringLength(value,
					MAXVKLETTERCOUNT, nameof(VkId));
				this._vkId = value;

				OnPropertyChanged(nameof(VkId));
			}
			
		}

		/// <summary>
		/// Sets and returns <see cref="Birthday"> values 
		/// </summary>
		public DateTime Birthday
		{
			get
			{
				return this._birthday;
			}
			set
			{
				DateValidator.AssertDate(value);
				this._birthday = value;
				OnPropertyChanged(nameof(Birthday));
			}
		}

		/// <summary>
		/// <see cref="Contact"> object constructor
		/// </summary>
		/// <param name="lasrName"><see cref="Surname"></param>
		/// <param name="firstName"><see cref="Name"/></param>
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

		/// <summary>
		/// Creates a <see cref="Contact"/> clone
		/// </summary>
		/// <returns>Returns a clone of the <see cref="Contact"/>
		/// object</returns>
		public object Clone()
        {
            return new Contact(FirstName, LastName,
				 new PhoneNumber(PhoneNumber.Number),  
				 Birthday,  Email, VkId);
		}
	}
}