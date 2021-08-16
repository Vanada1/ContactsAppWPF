using System;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ContactsApp;
using NUnit.Framework.Internal;

namespace ContactsApp.UnitTests
{
	[TestFixture]
	public class ProjectTests
    {
		[Test(Description = "Positive test of the Contacts setter")]
		public void TestContactsSet_CurrentValue()
		{
			Project project = new Project();
			var testList = new ObservableCollection<Contact>();

			Assert.DoesNotThrow(
				() => { project.Contacts = testList; },
				"Positive test of the Contacts setter not passed");
		}

		[Test(Description = "Test the sort")]
		public void TestSort_CorrectValue()
		{
			var project =new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A")
			};

			var expected = new Project();
			expected.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C")
			};

			var actual = new Project();
			actual.Contacts = project.SearchContacts(string.Empty);

			Assert.AreEqual(expected.Contacts[0].LastName, 
				actual.Contacts[0].LastName, "Dotes not sorted");
		}

		[Test(Description = "Test Sort without values")]
		public void TestSort_WithoutValues()
		{
			var project = new Project();

			var excepted = new ObservableCollection<Contact>();

			var actual = project.SearchContacts(string.Empty);

			Assert.AreEqual(excepted, actual,
				"Don't Contain Values");
		}

		[Test(Description = "Test Sort with null element")]
		public void TestSort_WithNullValues()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				null,
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A")
			};

			var expected = new Project();
			expected.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C")
			};

			var actual = new Project();
			actual.Contacts = project.SearchContacts(string.Empty);

			Assert.AreEqual(expected.Contacts[0].LastName,
				actual.Contacts[0].LastName, "Dotes not sorted");
		}

		[Test(Description = "Test the sort with substring")]
		public void TestSort_CorrectValueSubstring()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A")
			};

			var expected = new Project();
			expected.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A"),
			};

			var actual = new Project();
			actual.Contacts = project.SearchContacts("A");

			Assert.AreEqual(expected.Contacts[0].LastName,
				actual.Contacts[0].LastName, "Dotes not sorted");
		}

		[Test(Description = "Test Sort without values with substring")]
		public void TestSort_WithoutValuesSubstring()
		{
			var project = new Project();

			var excepted = new ObservableCollection<Contact>();

			var actual = project.SearchContacts("A");

			Assert.AreEqual(excepted, actual,
				"Don't Contain Values");
		}

		[Test(Description = "Test Sort with null element with substring")]
		public void TestSort_WithNullValuesSubstring()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				null,
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 12),
					"A", "A")
			};

			var expected = new Project();
			expected.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 12),
					"C", "C")
			};

			var actual = new Project();
			actual.Contacts = project.SearchContacts("C");

			Assert.AreEqual(expected.Contacts[0].LastName,
				actual.Contacts[0].LastName, "Dotes not sorted");
		}

		[Test(Description = "Birthday found")]
		public void TestFindBirthday_HasContacts()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 21),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 31),
					"A", "A")
			};

			var expected = new ObservableCollection<Contact>()
			{
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 31),
					"A", "A")
			};

			var actual = project.FindBirthdayContacts(
				new DateTime(1900, 12, 31));

			Assert.AreEqual(expected[0].LastName, 
				actual[0].LastName, "Fail to find people's birthday");
		}

		[Test(Description = "Birthday found")]
		public void TestFindBirthday_HasNotContacts()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>();

			var expected = new ObservableCollection<Contact>();

			var actual = project.FindBirthdayContacts(
				new DateTime(1900, 12, 31));

			Assert.AreEqual(expected,
				actual, "Fail to find people's birthday");
		}

		[Test(Description = "Birthday found")]
		public void TestFindIndex_HasContacts()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 21),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 31),
					"A", "A")
			};

			var expected = 2;
			var foundContact = new Contact("A", "A",
				new PhoneNumber("70000000000"),
				new DateTime(2001, 12, 31),
				"A", "A");

			var actual = project.FindIndex(foundContact);

			Assert.AreEqual(expected,
				actual, "Fail to find people's birthday");
		}

		[Test(Description = "Birthday found")]
		public void TestFindIndex_HasNotContacts()
		{
			var project = new Project();
			project.Contacts = new ObservableCollection<Contact>()
			{
				new Contact("C", "C",
					new PhoneNumber("70000000000"),
					new DateTime(2000, 12, 21),
					"C", "C"),
				new Contact("B", "B",
					new PhoneNumber("70000000000"),
					new DateTime(2010, 12, 12),
					"B", "B"),
				new Contact("A", "A",
					new PhoneNumber("70000000000"),
					new DateTime(2001, 12, 31),
					"A", "A")
			};

			var expected = -1;

			var actual = project.FindIndex(new Contact(
				"U", "U", new PhoneNumber("77800000000"),
				new DateTime(2001, 12, 31),
				"U", "U"));

			Assert.AreEqual(expected,
				actual, "Fail to find people's birthday");
		}

	}
}