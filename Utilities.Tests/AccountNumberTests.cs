using Xunit;
using FluentAssertions;

namespace Utilities.Tests;

public class AccountNumberTests
{
    [Theory]
    [InlineData("1150 12 34569", true)]
    [InlineData("1150.12.34569", true)]
    [InlineData("11501234569", true)]
    [InlineData("11501234567", false)]
    [InlineData("1150123456", false)]
    [InlineData("", false)]
    public void IsValid_Test(string? accountNumber, bool shouldBe)
    {
        //Arrange

        //Act
        var result = accountNumber.IsValid();

        //Assert
        result.Should().Be(shouldBe);
    }

    [Theory]
    [InlineData("1150 12 34569" , "DNB Bank ASA")]
    [InlineData("1234 12 34569" , "Unknown")]
    public void GetWitchBank_ShouldBeFalse(string? accountNumber, string bank)
    {
        //Arrange

        //Act
        var result = accountNumber.GetWitchBank();

        //Assert
        result.Should().Be(bank);
    }
}