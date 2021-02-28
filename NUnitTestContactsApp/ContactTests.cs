using System;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using ContactsAppBL;
using NUnit.Framework.Internal;

namespace ContactsApp.UnitTests
{
	[TestFixture]
	class ContactTests
	{
        private Contact CreateEmptyContact()
		{
			return new Contact(" ", " ", new PhoneNumber(70000000000),
				DateTime.Now, " ", " ");
		}

		//Test Name start
		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			var expected = "Name";

			var contact = CreateEmptyContact();
			contact.Name = expected;

			var actual = contact.Name;

			Assert.AreEqual(expected, actual, 
				"Getter Name returns incorrect value");
		}

		[TestCase("", "Name is not empty",
			TestName = "Assignment of the Name is empty")]
		[TestCase("NameNameNameNameNameNameNameNameNameNameNameNameNameName",
			"Name is not large of max value",
			TestName = "Assignment of the Name is large of max value")]
		public void TestNameSet_ArgumentException(string wrongValue,
			string message)
		{
			var contact = CreateEmptyContact();
			Assert.Throws<ArgumentException>(
				() => { contact.Name = wrongValue; },
				message);
		}

		[Test(Description = "Positive test of the Name setter")]
		public void TestNameSet_CorrectValue()
		{
			var contact = CreateEmptyContact();
			var name = "Name";
			Assert.DoesNotThrow(
				() => { contact.Name = name; },
				"Positive test of the Name setter not passed");
		}
		//Test Name end

		//Test Surname start
		[Test(Description = "Positive test of the Surname getter")]
		public void TestSurnameGet_CorrectValue()
		{
			var expected = "Surname";

			var contact = CreateEmptyContact();
			contact.Surname = expected;

			var actual = contact.Surname;

			Assert.AreEqual(expected, actual,
				"Getter Surname returns incorrect value");
		}

		[TestCase("", "Surname is not empty",
			TestName = "Assignment of the Surname is empty")]
		[TestCase("SurnameSurnameSurnameSurnameSurnameSurnameSurnameSurname",
			"Surname is not large of max value",
			TestName = "Assignment of the Surname is large of max value")]
		public void TestSurnameSet_ArgumentException(string wrongValue, 
			string message)
		{
			var contact = CreateEmptyContact();
			Assert.Throws<ArgumentException>(
				() => { contact.Surname = wrongValue; },
				message);
		}

		[Test(Description = "Positive test of the Surname setter")]
		public void TestSurnameSet_CorrectValue()
		{
			var contact = CreateEmptyContact();
			var surname = "Surname";
			Assert.DoesNotThrow(
				() => { contact.Surname = surname; },
				"Positive test of the Surname setter not passed");
		}
		//Test Surname End

		//Test Email start
		[Test(Description = "Positive test of the Email getter")]
		public void TestEmailGet_CorrectValue()
		{
			var expected = "Email";

			var contact = CreateEmptyContact();
			contact.Email = expected;

			var actual = contact.Email;

			Assert.AreEqual(expected, actual, 
				"Getter Email returns incorrect value");
		}

		[TestCase("", "Email is not empty",
			TestName = "Assignment of the Email is empty")]
		[TestCase("EmailEmailEmailEmailEmailEmailEmailEmailEmailEmailEmailEmail",
			"Email is not large of max value",
			TestName = "Assignment of the Email is large of max value")]
		public void TestEmailSet_ArgumentException(string wrongValue, 
			string message)
		{
			var contact = CreateEmptyContact();
			Assert.Throws<ArgumentException>(
				() => { contact.Email = wrongValue; },
				message);
		}

		[Test(Description = "Positive test of the Email setter")]
		public void TestEmailSet_CorrectValue()
		{
			var contact = CreateEmptyContact();
			var email = "Email";
			Assert.DoesNotThrow(
				() => { contact.Email = email; },
				"Positive test of the Email setter not passed");
		}
		//Test Email end

		//Test VkID start
		[Test(Description = "Positive test of the VKID getter")]
		public void TestVKIDGet_CorrectValue()
		{
			var expected = "VKID";

			var contact = CreateEmptyContact();
			contact.VkId = expected;

			var actual = contact.VkId;

			Assert.AreEqual(expected, actual, 
				"Getter VKID returns incorrect value");
		}

		[TestCase("", "VKID is not empty",
			TestName = "Assignment of the VKID is empty")]
		[TestCase("1234567890qwertyui",
			"VKID is not large of max value",
			TestName = "Assignment of the VKID is large of max value")]
		public void TestVKIDSet_ArgumentException(string wrongValue,
			string message)
		{
			var contact = CreateEmptyContact();
			Assert.Throws<ArgumentException>(
				() => { contact.VkId = wrongValue; },
				message);
		}

		[Test(Description = "Positive test of the VKID setter")]
		public void TestVKIDSet_CorrectValue()
		{
			var contact = CreateEmptyContact();
			var vkid = "VKID";
			Assert.DoesNotThrow(
				() => { contact.Name = vkid; },
				"Positive test of the VKID setter not passed");
		}
		//Test VkId end

		//Test PhoneNumber start
		[Test(Description = "Positive test of the PhoneNumber getter")]
		public void TestPhoneNumberGet_CorrectValue()
		{
			var expected = new PhoneNumber(78005553535);

			var contact = CreateEmptyContact();
			contact.PhoneNumber = expected;

			var actual = contact.PhoneNumber;

			Assert.AreEqual(expected, actual, 
				"Getter PhoneNumber returns incorrect value");
		}

		[TestCase(88005553535, "Number starts at 7",
			TestName = "Assignment of the Number starting not with 7")]
		[TestCase(880055535353, "Number has 11 numbers",
			TestName = "Assignment of the Number has not 11 numbers")]
		public void TestPhoneNumber_ArgumentException(long wrongNumber,
			string message)
		{
			var contact = CreateEmptyContact();
			Assert.Throws<ArgumentException>(
				() => { contact.PhoneNumber = new PhoneNumber(wrongNumber); },
				message);
		}

		[Test(Description = "Positive test of the PhoneNumber setter")]
		public void TestPhoneNumberSet_CorrectValue()
		{
			var contact = CreateEmptyContact();
			var phoneNumber = new PhoneNumber(78005553535);
			Assert.DoesNotThrow(
				() => { contact.PhoneNumber = phoneNumber; },
				"Positive test of the PhoneNumber setter not passed");
		}
		//Test PhoneNumber end

		//Test Birthday start
		[Test(Description = "Positive test of the Birthday getter")]
		public void TestBirthdayGet_CorrectValue()
		{
			var expected = new DateTime(2000,12,12);

			var contact = CreateEmptyContact();
			contact.Birthday = expected;

			var actual = contact.Birthday;

			Assert.AreEqual(expected, actual,
				"Getter Birthday returns incorrect value not passed");
		}

		[TestCase(1800, 1, 1,
			"Date not lower than minimum",
			TestName = "Assignment of the Birthday is less then min value")]
		[TestCase(3000, 1, 1,
			"Date not higher than maximum",
			TestName = "Assignment of the Birthday in the future")]
		public void TestBirthdaySet_ArgumentException(int year, int month,
			int day, string message)
		{
			var contact = CreateEmptyContact();
			var wrongValue = new DateTime(year, month, day);
			Assert.Throws<ArgumentException>(
				() => { contact.Birthday = wrongValue; },
				message);
		}

		[Test(Description = "Positive test of the Birthday setter")]
		public void TestBirthdaySet_CorrectValue()
		{
			var contact = CreateEmptyContact();
			var dateTime = new DateTime(2000, 12, 21);
			Assert.DoesNotThrow(
				() => { contact.Birthday = dateTime; },
				"Positive test of the PhoneNumber setter not passed");
		}
		//Test Birthday end

		//Test Constructor start
		[Test(Description = "Test constructor")]
		public void TestConstructor()
		{
			var expectedName = "Name";
			var expectedSurname = "Surname";
			var expectedPhoneNumber = new PhoneNumber(78005553535);
			var expectedBirthday = new DateTime(2000, 12, 12);
			var expectedEmail = "Email";
			var expectedVkId = "VkId";

			Assert.DoesNotThrow(() =>
			{
				var contact = new Contact(expectedName, expectedSurname,
					expectedPhoneNumber, expectedBirthday, expectedEmail,
					expectedVkId);
			}, "The constructor did not work"); 
		}
		//Test Constructor end
	}
}
