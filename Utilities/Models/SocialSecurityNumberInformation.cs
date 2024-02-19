using Utilities.Enums;
using static Utilities.SocialSecurityNumber;

namespace Utilities.Models;

public class SocialSecurityNumberInformation
{
    public bool IsValid { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? BirthNumberType { get; set; }
}
