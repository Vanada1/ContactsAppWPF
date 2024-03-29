﻿using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests;

[TestFixture]
public class ValidatorTests
{
    [TestCase(
        1600,
        1,
        1,
        "Exception: date is not below 1900",
        TestName = "Date below 1900")]
    [TestCase(3000, 1, 1, "Exception: date is not above today")]
    public void TestBirthdayValidator_ArgumentException(
        int year,
        int month,
        int day,
        string message)
    {
        var date = new DateTime(year, month, day);
        Assert.Throws<ArgumentException>(
            () =>
            {
                DateValidator.AssertDate(date);
            },
            message);
    }

    [Test(Description = "Correctly value of date")]
    public void TestBirthdayValidator_CorrectlyValue()
    {
        var date = new DateTime(2000, 12, 12);
        Assert.DoesNotThrow(
            () =>
            {
                DateValidator.AssertDate(date);
            },
            "Incorrect date values");
    }

    [Test(Description = "Correctly value of date")]
    public void TestAssertStringLength_CorrectlyValue()
    {
        Assert.DoesNotThrow(
            () =>
            {
                StringValidator.AssertStringLength(
                    "mem",
                    10,
                    null);
            },
            "Incorrect number");
    }

    [Test(Description = "Return empty string through GetClearPhoneNumber")]
    public void TestGetClearPhoneNumber_EmptyString()
    {
        var number = "adfasdasdfasdfasdf";

        var expected = "";

        var actual = StringValidator.GetClearPhoneNumber(number);

        Assert.AreEqual(
            expected,
            actual,
            "Actual is not empty sting");
    }

    [Test(Description = "Return number through GetClearPhoneNumber")]
    public void TestGetClearPhoneNumber_Number()
    {
        var number = "a8d800fa555s3d5a35sdfasdfasdf";

        var expected = "88005553535";

        var actual = StringValidator.GetClearPhoneNumber(number);

        Assert.AreEqual(
            expected,
            actual,
            "Actual is not empty sting");
    }

    [TestCase(
        "88005553535",
        11,
        "Start with 7",
        TestName = "Number start with not 7")]
    [TestCase(
        "792355865554",
        11,
        "Correct Phone number",
        TestName = "Number is not equal then value")]
    public void TestAssertPhoneNumber_IncorrectValue(
        string number,
        int maxCount,
        string message)
    {
        Assert.Throws<ArgumentException>(
            () =>
            {
                StringValidator.AssertPhoneNumber(
                    number,
                    maxCount);
            },
            message);
    }

    [Test(Description = "Correctly number")]
    public void TestAssertPhoneNumber_CorrectlyValue()
    {
        Assert.DoesNotThrow(
            () =>
            {
                StringValidator.AssertPhoneNumber("78005553535", 11);
            },
            "Incorrect date values");
    }
}