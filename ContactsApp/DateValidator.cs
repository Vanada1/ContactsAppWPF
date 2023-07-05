using System;

namespace ContactsApp;

/// <summary>
/// Checks if the date is correct
/// </summary>
public static class DateValidator
{
    /// <summary>
    /// Checks if the date is correct
    /// </summary>
    /// <param name="date"> </param>
    public static void AssertDate(DateTime date)
    {
        if (date.Year < 1900)
        {
            throw new ArgumentException("This year is less than 1900");
        }

        if (date > DateTime.Now)
        {
            throw new ArgumentException("This date is more than today");
        }
    }
}