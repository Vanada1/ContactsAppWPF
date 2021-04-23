using System;
using System.Linq;

namespace ContactsApp
{
	/// <summary>
	/// Support of work with strings
	/// </summary>
	public static class StringValidator
	{
		/// <summary>
		/// Throws an error if the line does not fit the range
		/// </summary>
		public static void AssertStringLength(string checkedString,
			int maxLength, string name)
		{
			if (checkedString.Length > maxLength)
			{
				throw new ArgumentException($"{name} too long. Maximum length is {maxLength}");
			}

			if (checkedString.Length == 0)
			{
				throw new ArgumentException($"Field {name} cannot be empty");
			}
		}

        /// <summary>
        /// Returns only digits of a number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static string GetClearPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Where(i => i >= '0' && i <= '9')
                .Aggregate("", (current, i) => current + i);
        }

		/// <summary>
		/// Throws an error if incorrect phone number
		/// </summary>
		/// <param name="number"></param>
		/// <param name="maxDigitCount"></param>
		public static void AssertPhoneNumber(string number, int maxDigitCount)
        {
	        if (number.Length != maxDigitCount)
	        {
		        throw new ArgumentException("Invalid phone number");
	        }

	        if (number[0] != '7')
	        {
		        throw new ArgumentException(
			        "The first digit is not 7");
	        }
		}
	}
}
