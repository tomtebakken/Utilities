using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Enums;
using Utilities.Models;

namespace Utilities;

/// <summary>
/// This SocialSecurityNumber utility helps get information ut of a norwegian social security number (Fødselsnummer). Including validating if the number is in a valid format or not.
/// </summary>
public static class SocialSecurityNumber
{
    /// <summary>
    /// Gets the available information of a norwegian social security number
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <returns></returns>
    public static SocialSecurityNumberInformation Information(this string? socialSecurityNumber)
    {
        return new SocialSecurityNumberInformation
        {
            IsValid = socialSecurityNumber.IsValidFormat(),
            DateOfBirth = socialSecurityNumber.GetDateOfBirth(),
            Gender = socialSecurityNumber.WitchGender(),
            BirthNumberType = socialSecurityNumber.BirthNumberType(),
        };
    }

    /// <summary>
    /// Checks a string based norwegian social security number (Fødselsnummer) to se if it is of a valid format. 
    /// It also tacks into consideration D and H-numbers, but not FH-numbers.
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <param name="controlDigits">Choice to exclude the use control digits (checksum) in validation</param>
    /// <returns>True if the number is of a valid format</returns>
    public static bool IsValidFormat(this string? socialSecurityNumber, bool controlDigits = true)
    {
        if (CorrectLength(socialSecurityNumber))
            return false;

        var digit = socialSecurityNumber
            .Select(character => int.Parse(character.ToString()))
            .ToArray();
        
        if (controlDigits)
        {
            int[] controlDigitsFirst = {3, 7, 6, 1, 8, 9, 4, 5, 2};
            int[] controlDigitsSecond = {5, 4, 3, 2, 7, 6, 5, 4, 3, 2};
            var checkSum1 = 11 - controlDigitsFirst.Select ((controlDigit, index) => controlDigit * digit[index]).Sum() % 11;
            var checkSum2 = 11 - controlDigitsSecond.Select ((controlDigit, index) => controlDigit * digit[index]).Sum() % 11;

            if (checkSum1 != digit[9] || checkSum2 != digit[10])
                return false;
        }

        if (!socialSecurityNumber.GetDateOfBirth().HasValue)
            return false;

        return true;
    }

    /// <summary>
    /// Gets the gender information from a norwegian social security number (Fødselsnummer).
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <returns>female if the ninth digit is even number, if not is male. if its not the correct length it returns none.</returns>
    public static Gender WitchGender(this string? socialSecurityNumber)
    {
        if (CorrectLength(socialSecurityNumber))
            return Gender.none;

        var digit = socialSecurityNumber
            .Select(character => int.Parse(character.ToString())).
            ToArray();

        return digit[8]%2 == 0 ? Gender.female : Gender.male;
    }

    /// <summary>
    /// Get what type of number the norwegian social security number (Fødselsnummer).
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <returns>
    /// The type of number it is. 
    /// If it is a not D-Number, H-Number or in error it's Normal
    /// If the Date is larger than 40 it's a D-Number. 
    /// If the Month is lager than 40 it's a H-Number.
    /// If both date and month is larger then 40 it's in error and an empty string is returned.
    /// </returns>
    public static string BirthNumberType(this string? socialSecurityNumber)
    {
        var dayOfMonth = int.Parse(socialSecurityNumber.AsSpan(0, 2));
        var Month = int.Parse(socialSecurityNumber.AsSpan(2, 2));

        if (dayOfMonth > 40 && Month > 40)
            return string.Empty;

        if (dayOfMonth > 40) 
            return "D-Number";

        if (Month > 40) 
            return "H-Number";
            
        return "Normal";
    }

    /// <summary>
    /// Gets the date of birth from a norwegian social security number (Fødselsnummer).
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <returns>The Date of birth if the number is of the correct length and format</returns>
    public static DateTime? GetDateOfBirth(this string? socialSecurityNumber)
    {
        if (CorrectLength(socialSecurityNumber))
            return null;

        var dayOfMonth = int.Parse(socialSecurityNumber.AsSpan(0, 2));
        var Month = int.Parse(socialSecurityNumber.AsSpan(2, 2));
        
        if (dayOfMonth > 40 && Month > 40)
            return null;

        if (dayOfMonth > 40) 
            dayOfMonth -= 40;

        if (Month > 40)
            Month -= 40;
        
        if (!DateTime.TryParseExact(
            $"{dayOfMonth:D2}{Month:D2}{socialSecurityNumber.YearOfBirth()}", 
            "ddMMyyyy", 
            CultureInfo.CreateSpecificCulture("nb-NO"), 
            DateTimeStyles.None, 
            out var dateOfBirth))
            return null;

        return dateOfBirth;
    }

    /// <summary>
    /// Gets the year of birth from a Norwegian social security number (Fødselsnummer)
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <returns>4 digit number representing the year of birth</returns>
    public static int YearOfBirth(this string? socialSecurityNumber)
    {
        if (CorrectLength(socialSecurityNumber))
            return 0;

        var year = int.Parse(socialSecurityNumber.AsSpan(4, 2));
        var individualNumber = int.Parse(socialSecurityNumber.AsSpan(6, 3));
        var century = individualNumber switch
        {
            <= 499 => 1900,
            >= 500 and <= 749 => 1800,
            >= 750 and <= 899 => 2000,
            _ => 1900
        };
        
        return century + year;
    }

    /// <summary>
    /// Checks if the norwegian social security number (Fødselsnummer) in not null or empty.
    /// It also checks that it is of the correct length and only contains digits and not any other characters.
    /// </summary>
    /// <param name="socialSecurityNumber">Norwegian social security number (Fødselsnummer)</param>
    /// <returns>true is all the criteria are correct</returns>
    private static bool CorrectLength(string? socialSecurityNumber)
    {
        return string.IsNullOrEmpty(socialSecurityNumber) || !new Regex(@"^\d{11}$").IsMatch(socialSecurityNumber);
    }
}

