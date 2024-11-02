// -----------------------------------------------------------------------
// <copyright file="StringEnumTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Models;


[TestFixture]
internal sealed class StringEnumTests
{
    [Test]
    public void Find_ShouldReturnNull_WhenInputIsNull()
    {
        DispositionType.Find(null).Should().BeNull();
    }

    [Test]
    public void Find_ShouldReturnNull_WhenThereIsNoSuchEnumValue()
    {
        DispositionType.Find("123").Should().BeNull();
    }

    [Test]
    public void Find_ShouldReturnEnumValue_WhenThereIsCorrespondingEnumValue()
    {
        DispositionType.Find(DispositionType.Attachment.ToString()).Should()
            .Be(DispositionType.Attachment);
    }

    [Test]
    public void GetHashCode_ShouldReturnHashCodeForInternalValue()
    {
        var expected = DispositionType.Attachment.ToString().GetHashCode(StringComparison.Ordinal);

        DispositionType.Attachment.GetHashCode().Should().Be(expected);
    }

    [Test]
    public void Equals_ShouldReturnTrue_WhenEnumValuesAreTheSame()
    {
        DispositionType.Attachment.Equals(DispositionType.Attachment).Should().BeTrue();
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenEnumValuesAreDifferent()
    {
        DispositionType.Attachment.Equals(DispositionType.Inline).Should().BeFalse();
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenEnumValuesAreDifferent_2()
    {
        DispositionType.Attachment.Equals(new DispositionType()).Should().BeFalse();
    }

    [Test]
    public void Equals_ShouldReturnFalse_WhenOtherIsNull()
    {
        DispositionType.Attachment.Equals(null).Should().BeFalse();
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
