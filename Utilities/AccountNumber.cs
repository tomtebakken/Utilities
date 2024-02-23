using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Utilities.Models;

namespace Utilities;

/// <summary>
/// AccountNumber utility validates if Norwegian account number is of a valid format and can gets witch bank it belongs to.
/// </summary>
public static class AccountNumber
{
    private static string _jsonFilePath = "json/Norwegian BIC-IBAN table.json";

    /// <summary>
    /// Checks is the bank Account is of a valid format. 
    /// valid account formats are 'xxxx yy zzzzc', 'xxxx yy.zzzzc' or 'xxxxyyzzzzc'
    /// The first four digits (xxxx) is the bank identifier
    /// The two next (yy) is the account type
    /// The four next (zzzz) are the account number
    /// The last digit is a control digit
    /// </summary>
    /// <param name="accountNumber">Bank Account Number</param>
    /// <returns>true if valid</returns>
    public static bool IsValid(this string? accountNumber)
    {
        if (accountNumber.AcceptableFormatAndLength())
            return false;

        var digit = accountNumber
            .Where(char.IsDigit)
            .Select(character => int.Parse(character.ToString()))
            .ToArray();

        if (digit.Count() != 11)
            return false;

        int[] controlDigitsFirst = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        var checkSum1 = 11 - controlDigitsFirst.Select((controlDigit, index) => controlDigit * digit[index]).Sum() % 11;

        if (checkSum1 != digit[10])
            return false;

        return true;
    }

    /// <summary>
    /// Checks what Bank the bank account number belongs to. It looks up if the bank using bank Identification in the JSON file Norwegian BIC-IBAN (Depending on the age this file may be out of date. It was downloaded in 2024).
    /// </summary>
    /// <param name="accountNumber">Bank Account Number</param>
    /// <returns>Name of the Bank. If the bank is not found Unknown is returned</returns>
    public static string GetWitchBank(this string? accountNumber)
    {
        var bankIdentifications = GetBankIdentification();

        if (bankIdentifications == null || accountNumber.AcceptableFormatAndLength())
            return "Unknown";

        BankIdentification bankIdentification = bankIdentifications.FirstOrDefault(bankIdentification => bankIdentification.Bankidentifier == accountNumber.Substring(0 ,4));
        return bankIdentification != null ? bankIdentification.Bank.TrimStart().TrimEnd() : "Unknown";
    }

    private static bool AcceptableFormatAndLength(this string? accountNumber)
    {
        return string.IsNullOrEmpty(accountNumber) || !new Regex(@"^\d{4} \d{2} \d{5}$|^\d{4}\.\d{2}\.\d{5}$|^\d{11}$").IsMatch(accountNumber);
    }

    private static List<BankIdentification>? GetBankIdentification()
    {
        string jsonString = File.ReadAllText(_jsonFilePath);
        return JsonConvert.DeserializeObject<List<BankIdentification>>(jsonString);
    }
}