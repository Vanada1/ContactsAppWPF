using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppBL
{
	/// <summary>
	/// The <see cref="Contact"> class contains information about the contact: 
	/// <see cref="Name">, <see cref="Surname">, <see cref="PhoneNumber">,
	/// <see cref="Birthday">, <see cref="Email">, <see cref="VkId">
	/// </summary>
	public class Contact : ICloneable
    {
		/// <summary>
		/// Max count of letters for <see cref="Name"/>, 
		/// <see cref="Surname"/>, <see cref="Email"/>
		/// </summary>
        public const int MAXLETTERCOUNT = 50;

		/// <summary>
		/// Max count of letters for <see cref="VkId"/>
		/// </summary>
		public const int MAXVKLETTERCOUNT = 15;

		/// <summary>
		/// Contact <see cref="Name"/>
		/// </summary>
		private string _name;

		/// <summary>
		/// Contact <see cref="Surname"/>
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

		/// <summary>
		/// Sets and returns <see cref="Name"> values 
		/// </summary>
		public string Name
		{
			get 
			{
				return _name; 
			}
			set
			{
				StringValidator.AssertStringLength(value,
					MAXLETTERCOUNT, nameof(Name)); 
				this._name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
			}
			
		}

		/// <summary>
		/// Sets and returns <see cref="Surname"> values
		/// </summary>
		public string Surname
		{
			get 
			{ 
				return this._surname; 
			}
			set
			{
				StringValidator.AssertStringLength(value,
					MAXLETTERCOUNT, nameof(Surname));
				this._surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); ;
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
            }
		}

		/// <summary>
		/// <see cref="Contact"> object constructor
		/// </summary>
		/// <param name="surname"><see cref="Surname"></param>
		/// <param name="name"><see cref="Name"/></param>
		/// <param name="phoneNumber"><see cref="PhoneNumber"/></param>
		/// <param name="birthday"><see cref="Birthday"/></param>
		/// <param name="email"><see cref="Email"/></param>
		/// <param name="vkId"><see cref="VkId"/></param>
		public Contact(string name, string surname,
			 PhoneNumber phoneNumber, DateTime birthday,
			 string email, string vkId)
		{
			this.Surname = surname;
			this.Name = name;
			this.PhoneNumber = phoneNumber;
			this.Birthday = birthday;
			this.Email = email;
			this.VkId = vkId;
		}

		/// <summary>
		/// Creates a <see cref="Contact"/> clone
		/// </summary>
		/// <returns>Returns a clone of the <see cref="Contact"/>
		/// object</returns>
		public object Clone()
        {
            return new Contact(this.Name, this.Surname,
				 new PhoneNumber(this.PhoneNumber.Number),  
				 this.Birthday,  this.Email, this.VkId);
		}
	}
}