namespace Utilities.Common;

internal static class Modulus
{
	/// <summary>
	/// Calculate 10 modulus check (checksum) digit of the sett of incoming digits.
	/// </summary>
	/// <param name="digits">An array of digits</param>
	/// <returns>the 10 waited modulus sum</returns>
	public static int Mod10CalculateCheckDigit(this int[] digits)
	{
		var sumOfDigits = digits
			.Take(digits.Length - 1)
			.Reverse()
			.Select((digit, index) =>
			{
				if (index % 2 == 0)
				{
					digit *= 2;
					digit = digit > 9 ? (digit % 10) + 1 : digit;
				}

				return digit;
			})
			.Sum();
			var sumMod10 = 10 - sumOfDigits % 10;
		return sumMod10 >= 10 ? sumMod10 % 10 : sumMod10;
	}

	/// <summary>
	/// Calculate 11 modulus check (checksum) digit of the sett of incoming digits.
	/// </summary>
	/// <param name="digits">An array of digits</param>
	/// <returns>the 11 waited modulus sum</returns>
	public static int Mod11CalculateCheckDigit(this int[] digits)
	{
		var controlDigitsPattern = digits.Mod11ControlDigitsPattern();

		var sumOfDigits = digits
			.Take(digits.Length - 1)
			.Reverse()
			.Select((digit, index) => digit * controlDigitsPattern[index])
			.Sum();

		var sumMod11 = 11 - sumOfDigits % 11;
		return sumMod11 >= 11 ? 0 : sumMod11;
	}

	/// <summary>
	/// Creates the control digits pattern for the MOD11 (modulus 11) from the number of digits in the incoming array minus the last digit. 
	/// All digits should be sent in.
	/// </summary>
	/// <param name="digits">An array of digits</param>
	/// <returns></returns>
	private static int[] Mod11ControlDigitsPattern(this int[] digits)
	{
		var controlDigitsPattern = new int[digits.Length - 1];

		for (int i = 0; i < digits.Length - 1; i++)
		{
			if (i == 0)
				controlDigitsPattern[i] = 2;
			else
				controlDigitsPattern[i] = controlDigitsPattern[i - 1] == 7 ? 2 : controlDigitsPattern[i - 1] + 1;
		}

		return controlDigitsPattern;
	}
}
