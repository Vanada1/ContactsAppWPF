namespace ContactsApp
{
	/// <summary>
	/// Class <see cref="PhoneNumber"> contains the telephone number of the person
	/// </summary>
	public class PhoneNumber
	{
		/// <summary>
		/// Number phone
		/// </summary>
		private long _number;

		/// <summary>
		/// Max count of <see cref="Number"/>
		/// </summary>
		public const int MAXDIGITCOUNT = 11;

		/// <summary>
		/// Sets and returns <see cref="Number"> values 
		/// </summary>
		public long Number
		{
			get 
			{
				return this._number;
			}
			set
			{
               StringValidator.AssertPhoneNumber(value, MAXDIGITCOUNT);
				this._number = value;
			}
		}

		/// <summary>
		/// <see cref="PhoneNumber"/> constructor
		/// </summary>
		/// <param name="number">
		/// Gets a phone number
		/// </param>
		public PhoneNumber(long number)
		{
			this.Number = number;
		}
	}
}
