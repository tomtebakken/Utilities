using System.Text.RegularExpressions;

namespace Utilities.Common;

/// <summary>
/// This class contains common validations
/// </summary>
public static class Validation
{
	/// <summary>
	/// Checks to see if value is not null or empty and that it matches the regular expression
	/// </summary>
	/// <param name="value">value to check</param>
	/// <param name="regExString">regular expression</param>
	/// <returns>true if the value passes the criteria</returns>
	public static bool LengthAndFormat(this string? value, Regex regExString)
	{
		return string.IsNullOrEmpty(value) || !regExString.IsMatch(value);
	}
}
