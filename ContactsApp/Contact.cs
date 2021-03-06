using System;
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
	public class Contact : ICloneable, INotifyPropertyChanged, IDataErrorInfo
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
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		/// <summary>
		/// Sets and returns <see cref="FirstName"> values 
		/// </summary>
		public string FirstName
		{
			get => _name;
            set
			{ 
				_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
				OnPropertyChanged(nameof(FirstName));
			}
			
		}

		/// <summary>
		/// Sets and returns <see cref="LastName"> values
		/// </summary>
		public string LastName
		{
			get => this._surname;
            set
			{
				this._surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
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
			get => this._vkId;
            set
			{
				this._vkId = value;

				OnPropertyChanged(nameof(VkId));
			}
			
		}

		/// <summary>
		/// Sets and returns <see cref="Birthday"> values 
		/// </summary>
		public DateTime Birthday
		{
			get => this._birthday;
            set
			{
				this._birthday = value;
				OnPropertyChanged(nameof(Birthday));
			}
		}

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

        public Contact()
        {
			PhoneNumber = new PhoneNumber();
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

        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;
                var properties = GetType().GetProperties();
                var foundProperty = properties.Select(o => o)
                    .First(o => o.Name == columnName);

                try
                {
                    var propertyValue = foundProperty.GetValue(this);

					if(propertyValue is DateTime dateTime)
                    {
                        DateValidator.AssertDate(dateTime);
                    }
                    else
                    {
						var nameProperty = foundProperty.Name;
                        var maxLetters = nameProperty == nameof(VkId) ?
                            MaxVkLettersCount
                            : MaxLettersCount;
                        StringValidator.AssertStringLength(propertyValue.ToString(),
                            maxLetters, nameProperty);
					}
                }
                catch (ArgumentException e)
                {
                    error = e.Message;
                }

                return error;
            }
        }

        public string Error { get; }
    }
}