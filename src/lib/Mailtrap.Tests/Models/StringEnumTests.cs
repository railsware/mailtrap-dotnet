// -----------------------------------------------------------------------
// <copyright file="StringEnumTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Models;


[TestFixture]
internal sealed class StringEnumTests
{
    [Test]
    public void Find_ShouldReturnNull_WhenInputIsNull()
    {
        SpecifierType.Find(null).Should().BeNull();
    }

    [Test]
    public void Find_ShouldReturnNull_WhenThereIsNoSuchEnumValue()
    {
        SpecifierType.Find("123").Should().BeNull();
    }

    [Test]
    public void Find_ShouldReturnEnumValue_WhenThereIsCorrespondingEnumValue()
    {
        SpecifierType.Find(SpecifierType.ApiToken.ToString()).Should()
            .Be(SpecifierType.ApiToken);
    }

    [Test]
    public void GetHashCode_ShouldReturnHashCodeForInternalValue()
    {
        var expected = SpecifierType.ApiToken.ToString().GetHashCode(StringComparison.Ordinal);

        SpecifierType.ApiToken.GetHashCode().Should().Be(expected);
    }

    [Test]
    public void Equals_ShouldReturnTrue_WhenEnumValuesAreTheSame()
    {
        SpecifierType.ApiToken.Equals(SpecifierType.ApiToken).Should().BeTrue();
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenEnumValuesAreDifferent()
    {
        SpecifierType.ApiToken.Equals(SpecifierType.User).Should().BeFalse();
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenEnumValuesAreDifferent_2()
    {
        SpecifierType.ApiToken.Equals(new SpecifierType()).Should().BeFalse();
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenOtherIsNull()
    {
        SpecifierType.ApiToken.Equals(null).Should().BeFalse();
    }


    private sealed record EnumTest : StringEnum<EnumTest>
    {
        public static EnumTest Value1 { get; } = Define("Value1");
        public static EnumTest Value2 { get; } = Define("Value1"); // Should throw
    }

    [Test]
    public void CreatingDuplicateValue_ShouldThrowTypeInitializationException()
    {
        var act = () => new EnumTest();

        act.Should().Throw<TypeInitializationException>();
    }
}
