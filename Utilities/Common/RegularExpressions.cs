using System.Text.RegularExpressions;

namespace Utilities.Common;

public static class RegularExpressions
{
	public static Regex KidNumberFormat = new(@"^\d{3,25}$");

	public static Regex AccountNumberFormat = new(@"^\d{4} \d{2} \d{5}$|^\d{4}\.\d{2}\.\d{5}$|^\d{11}$");

	public static Regex SocialSecurityNumberFormat = new(@"^\d{11}$");
}
