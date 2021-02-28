using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContactsApp
{
	/// <summary>
	/// contains all the data about the <see cref="Project"/>
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Contains all <see cref="Contacts"/> at the moment
		/// </summary>
		public ObservableCollection<Contact> Contacts { set; get; } = new ObservableCollection<Contact>();

		/// <summary>
		/// Sort contacts list
		/// </summary>
		/// <returns>All sorted contacts</returns>
		private IOrderedEnumerable<Contact> SortContacts()
		{
			for (int i = 0; i < Contacts.Count; i++)
			{
				if (Contacts[i] == null)
				{
					Contacts.RemoveAt(i);
				}
			}

			return Contacts.OrderBy(
				contact => contact.LastName);
		}

		/// <summary>
		/// Sorting all contacts
		/// </summary>
		/// <param name="substring">
		/// Searches for contacts by First Name and Last Name 
		/// </param>
		/// <returns>
		/// Returns all contacts that have a <paramref name="substring"/>
		/// </returns>
		public ObservableCollection<Contact> SearchContacts(string substring)
        {
			var contacts = new List<Contact>();
	        var response = SortContacts().Where(contact => contact.FirstName.Contains(substring) ||
                                                        contact.LastName.Contains(substring)).ToArray();
            
			return response.Length == 0 ? Contacts : new ObservableCollection<Contact>(response);
		}

		/// <summary>
		/// Find All people who has Birthday on a specific date
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public ObservableCollection<Contact> FindBirthdayContacts(DateTime date)
        {
            var response = Contacts.Where(contact =>
                contact.Birthday.Day == date.Date.Day && contact.Birthday.Month == date.Month).ToArray();

			return new ObservableCollection<Contact>(response);
		}

		/// <summary>
		/// Find first Contact with the same <see cref="Name"/>
		/// and <see cref="Surname"/>
		/// </summary>
		/// <param name="contact"></param>
		/// <returns></returns>
		public int FindIndex(Contact contact)
		{
			for (int i = 0; i < Contacts.Count; i++)
			{
				if (Contacts[i].FirstName == contact.FirstName && 
				    Contacts[i].LastName == contact.LastName)
				{
					return i;
				}
			}

			return -1;
		}
	}

	
}
