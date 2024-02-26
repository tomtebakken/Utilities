using Xunit;
using FluentAssertions;
using System;
using System.Globalization;
using Utilities.Enums;
using Utilities.Models;

namespace Utilities.Tests;

public class SocialSecurityNumber
{
    [Theory]
    [InlineData("70019950032", true, Gender.female, "D-Number", "30.01.1899")]
    [InlineData("51111199993", true, Gender.male, "D-Number", "11.11.1911")]
    [InlineData("50069949824", true, Gender.female, "D-Number", "10.06.1999")]
    [InlineData("31012312388", true, Gender.male, "Normal", "31.01.1923")]
    [InlineData("71012312371", true, Gender.male, "D-Number", "31.01.1923")]
    [InlineData("31412312345", true, Gender.male, "H-Number", "31.01.1923")]
    [InlineData("29022012337", true, Gender.male, "Normal", "29.02.1920")]
    [InlineData("31412312345", false, Gender.male, "H-Number", "31.01.1923")]
    [InlineData("3141231234", false, Gender.male, "H-Number", "31.01.1923")]
    [InlineData("31412312", false, Gender.none, "H-Number", "31.01.1923")]
    [InlineData("314123", false, Gender.none, "H-Number", "31.01.1923")]
    public void Information_ShouldBeTrue(string? socialSecurityNumber, bool isValid, Gender gender, string numberType, string dateOfBirth)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.Information();

        //Assert
         result.Equals(new SocialSecurityNumberInformation{ IsValid = isValid, Gender = gender, BirthNumberType = numberType,  DateOfBirth =  DateTime.Parse(dateOfBirth, CultureInfo.CreateSpecificCulture("nb-NO"))});
    }

    [Theory]
    [InlineData("70019950032", true)]
    [InlineData("51111199993", true)]
    [InlineData("50069949824", true)]
    [InlineData("31012312388", true)]
    [InlineData("71012312371", true)]
    [InlineData("31412312345", false)]
    [InlineData("29022012337", true)]
    public void IsValidFormatted_ShouldBeTrue(string? socialSecurityNumber, bool controlDigits)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.IsValidFormat(controlDigits);

        //Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("31412312345")]
    [InlineData("31042312345")]
    [InlineData("71412312345")]
    [InlineData("33412312345")]
    [InlineData("29022312345")]
    public void IsValidFormatted_ShouldBeFalse(string? socialSecurityNumber)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.IsValidFormat();

        //Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("70019950032", Gender.female)]
    [InlineData("51111199993", Gender.male)]
    [InlineData("50069949824", Gender.female)]
    [InlineData("31012312388", Gender.male)]
    [InlineData("310123", Gender.none)]
    [InlineData("", Gender.none)]
    public void WitchGender_ShouldBeFalse(string? socialSecurityNumber, Gender gender)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.WitchGender();

        //Assert
        result.Should().Be(gender);
    }



    [Theory]
    [InlineData("31012312388", "Normal")]
    [InlineData("71012312371", "D-Number")]
    [InlineData("31412312345", "H-Number")]
    [InlineData("29022012337", "Normal")]
    [InlineData("", "")]
    public void BirthdayNumberType_ShouldBeTrue(string? socialSecurityNumber, string numberType)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.BirthNumberType();

        //Assert

        result.Should().Be(numberType);
    }

    [Theory]
    [InlineData("70019950032", "30.01.1899")]
    [InlineData("51111199993", "11.11.1911")]
    [InlineData("50069949824", "10.06.1999")]
    [InlineData("31012312388", "31.01.1923")]
    [InlineData("71012312371", "31.01.1923")]
    [InlineData("31412312345", "31.01.1923")]
    [InlineData("29022012337", "29.02.1920")]
    public void GetDateOfBirth_ShouldBeTrue(string? socialSecurityNumber, string dateOfBirth)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.GetDateOfBirth();

        //Assert

        result.Should().Be(DateTime.Parse(dateOfBirth, CultureInfo.CreateSpecificCulture("nb-NO")));
    }

    [Theory]
    [InlineData("70019950032", 1899)]
    [InlineData("51111199993", 1911)]
    [InlineData("50069949824", 1999)]
    [InlineData("31012312388", 1923)]
    [InlineData("71012312371", 1923)]
    [InlineData("31412312345", 1923)]
    [InlineData("29022012337", 1920)]
    [InlineData("290220", 0)]
    public void YearOfBirth_ShouldBeTrue(string? socialSecurityNumber, int year)
    {
        //Arrange

        //Act
        var result = socialSecurityNumber.YearOfBirth();

        //Assert
        result.Should().Be(year);
    }

}