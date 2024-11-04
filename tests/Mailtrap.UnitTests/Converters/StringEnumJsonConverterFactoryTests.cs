// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Converters;


[TestFixture]
internal sealed class StringEnumJsonConverterFactoryTests
{
    private readonly JsonSerializerOptions _options = MailtrapJsonSerializerOptions.Default;


    [Test]
    public void Serialize_ShouldUseConverterFactory()
    {
        JsonSerializer
            .Serialize(DispositionType.Attachment, _options)
            .Should()
            .Be(DispositionType.Attachment.ToString().Quoted());

        JsonSerializer
            .Serialize(DispositionType.Inline, _options)
            .Should()
            .Be(DispositionType.Inline.ToString().Quoted());
    }

    [Test]
    public void Deserialize_ShouldUseConverterFactory()
    {
        JsonSerializer
            .Deserialize<DispositionType>(DispositionType.Inline.ToString().Quoted(), _options)
            .Should()
            .Be(DispositionType.Inline);

        JsonSerializer
            .Deserialize<DispositionType>(DispositionType.Attachment.ToString().Quoted(), _options)
            .Should()
            .Be(DispositionType.Attachment);
    }


    private sealed record EnumTest : StringEnum<EnumTest>
    {
        public static EnumTest Value1 { get; } = Define("Value1");
        public static EnumTest Value2 { get; } = Define("Value2");
    }

    [Test]
    public void Deserialize_ShouldThrow_WhenInvalidTypeSpecified()
    {
        var act1 = () => JsonSerializer
            .Deserialize<bool>(DispositionType.Inline.ToString().Quoted(), _options);

        act1.Should().Throw<JsonException>();

        var act2 = () => JsonSerializer
            .Deserialize<EnumTest>(DispositionType.Attachment.ToString().Quoted(), _options);

        act2.Should().Throw<JsonException>();
    }
}
