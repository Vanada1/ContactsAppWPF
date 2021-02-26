using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppBL
{
	public static class DateValidator
	{
		public static void AssertDate(DateTime date)
		{
			if (date.Year < 1900)
			{
				throw new ArgumentException(
					"This year is less than 1900");
			}

			if (date > DateTime.Now)
			{
				throw new ArgumentException(
					"This date is more than today");
			}
		}
	}
}
