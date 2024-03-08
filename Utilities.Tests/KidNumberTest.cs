using Xunit;
using System.IO;
using FluentAssertions;

namespace Utilities.Tests;

public class KidNumberTest
{
	[Theory]
	[InlineData("TestData/KidNumbers.txt")]
	public void ValidateKidNumbersFromFile(string filePath)
	{
		// Read all lines from the file
		var kidNumbers = File.ReadAllLines(filePath);

		foreach (var kidNumber in kidNumbers)
		{
			// Arrange

			// Act
			var result = kidNumber.KidNumberIsValid();

			// Assert
			Assert.True(result, $"KID number {kidNumber} should be valid.");
		}
	}

	[Theory]
	[InlineData("52", false)]
	[InlineData("5868", true)]
	[InlineData("1610", true)]
	[InlineData("2240", true)]
	[InlineData("5835", true)]
	[InlineData("3000924872", true)]
	[InlineData("52407", true)]
	[InlineData("09837", true)]
	[InlineData("1349732", true)]
	[InlineData("4890426", true)]
	[InlineData("736504", true)]
	[InlineData("170258", true)]
	[InlineData("8607343", true)]
	[InlineData("0484626", true)]
	[InlineData("1783444811", true)]
	[InlineData("8549937962", true)]
	[InlineData("73277575841004866859", true)]
	[InlineData("37265353216270124010", true)]
	[InlineData("9144018081422460814781921", true)]
	[InlineData("1894930347812134143387447", true)]
	public void ValidateKidNumbers(string? kidNumber, bool shouldBe)
	{
			// Arrange

			// Act
			var result = kidNumber.KidNumberIsValid();

		// Assert
		result.Should().Be(shouldBe);
	}
}