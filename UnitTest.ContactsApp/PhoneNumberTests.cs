﻿using NUnit.Framework;

namespace ContactsApp.UnitTests;

[TestFixture]
public class PhoneNumberTests
{
    private PhoneNumber CreateClearPhoneNumber()
    {
        return new PhoneNumber("70000000000");
    }

    [Test(Description = "Positive test of the Number getter")]
    public void TestNumberGet_CorrectValue()
    {
        var expected = "78005553535";

        var phoneNumber = CreateClearPhoneNumber();
        phoneNumber.Number = expected;

        var actual = phoneNumber.Number;

        Assert.AreEqual(
            expected,
            actual,
            "Getter Number returns incorrect value");
    }

    [TestCase(
        "88005553535",
        "An exception should occur if the phone Number starts at 7",
        TestName = "Assignment of the Number starting not with 7")]
    [TestCase(
        "780055535353",
        "An exception should occur if the phone Number has 11 numbers",
        TestName = "Assignment of the Number has not 11 numbers")]
    public void TestNumberSet_ArgumentException(string wrongNumber, string message)
    {
        var phoneNumber = CreateClearPhoneNumber();
        phoneNumber.Number = wrongNumber;
        Assert.IsTrue(phoneNumber.HasErrors, message);
    }

    [Test(Description = "Positive test of the Number setter")]
    public void TestNumberSet_CorrectValue()
    {
        var number = "78005553535";

        var phoneNumber = CreateClearPhoneNumber();
        Assert.DoesNotThrow(
            () =>
            {
                phoneNumber.Number = number;
            },
            "Positive test of the Number setter not passed");
    }

    [Test(Description = "Positive test of the Constructor")]
    public void TestConstructorPhoneNumber_CorrectValue()
    {
        var number = "78005553535";
        Assert.DoesNotThrow(
            () =>
            {
                var phoneNumber = new PhoneNumber(number);
            },
            "Constructor is not passed");
    }
}