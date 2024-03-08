using System.Text.RegularExpressions;

namespace Utilities.Common;

public static class RegularExpressions
{
	public static Regex KidNumberFormat = new(@"^\d{3,25}$");
}
