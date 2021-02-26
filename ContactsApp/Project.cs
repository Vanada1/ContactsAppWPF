using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ContactsAppBL
{
	/// <summary>
	/// contains all the data about the <see cref="Project"/>
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Contains all <see cref="Contacts"/> at the moment
		/// </summary>
		public List<Contact> Contacts { set; get; } = new List<Contact>();

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
				contact => contact.Surname);
			var contacts = new List<Contact>();
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
		public List<Contact> SearchContacts(string substring)
        {
			var contacts = new List<Contact>();
	        var query = SortContacts();
			foreach (var i in query)
			{
				if (i.Surname.Contains(substring))
				{
					contacts.Add(i);
				}
				else if (i.Name.Contains(substring))
				{
					contacts.Add(i);
				}
			}

			return contacts;
		}

		/// <summary>
		/// Looking for all non-zero contacts
		/// </summary>
		/// <returns>Returns all contacts</returns>
		public List<Contact> SearchContacts()
        {
			var contacts = new List<Contact>();
	        var query = SortContacts();
	        foreach (var i in query)
	        {
		        contacts.Add(i);
	        }

	        return contacts;
		}

		/// <summary>
		/// Find All people who has Birthday on a specific date
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public List<Contact> FindBirthdayContacts(DateTime date) 
        {
			var birthdayContacts = new List<Contact>();
			foreach (var contact in Contacts)
			{
				if (contact.Birthday.Day == date.Day &&
				    contact.Birthday.Month == date.Month)
				{
					birthdayContacts.Add(contact);
				}
			}

			return birthdayContacts;
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
				if (Contacts[i].Name == contact.Name && 
				    Contacts[i].Surname == contact.Surname)
				{
					return i;
				}
			}

			return -1;
		}
	}

	
}
