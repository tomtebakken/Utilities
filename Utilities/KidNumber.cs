using Utilities.Common;

namespace Utilities;

/// <summary>
/// KID stands for Customer Identification Number, and is a number used in the payment of bills in Norway.
/// The number is unique for each bill and identifies the customer and the claim being paid.
/// This information is read and registered automatically by the bank, providing the sender of the bill with an overview of received payments.
/// A KID number can be from 3 to 25 digits long, and the last digit is a check digit.
/// This is generated based on the other numbers and is intended to reveal whether a payer has entered the KID number incorrectly.
/// </summary>
public static class KidNumber
{
	/// <summary>
	/// Checks to see if the KID number is a valid MOD10 (Modulus 10) or MOD11 (Modulus 11) number
	/// </summary>
	/// <param name="kidNumber">Customer Identification Number (KID number)</param>
	/// <returns>true if valid MOD10 (Modulus 10) or MOD11 (Modulus 11) number</returns>
	public static bool KidNumberIsValid(this string? kidNumber)
	{
		if (kidNumber.LengthAndFormat(RegularExpressions.KidNumberFormat))
			return false;

		var digits = kidNumber
			.Select(character => 
				int.Parse(character.ToString()))
			.ToArray();

		var sumMod10 = digits.Mod10CalculateCheckDigit();
		var sumMod11 = digits.Mod11CalculateCheckDigit();

		if (digits.Last() == sumMod10 || digits.Last() == sumMod11)
			return true;

		return false;
	}
}
