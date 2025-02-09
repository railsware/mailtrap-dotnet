// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Core.Converters;


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
            .Be(DispositionType.Attachment.ToString().AddDoubleQuote());

        JsonSerializer
            .Serialize(DispositionType.Inline, _options)
            .Should()
            .Be(DispositionType.Inline.ToString().AddDoubleQuote());
    }

    [Test]
    public void Deserialize_ShouldUseConverterFactory()
    {
        JsonSerializer
            .Deserialize<DispositionType>(DispositionType.Inline.ToString().AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.Inline);

        JsonSerializer
            .Deserialize<DispositionType>(DispositionType.Attachment.ToString().AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.Attachment);
    }

    [Test]
    public void Deserialize_ShouldThrow_WhenInvalidTypeSpecified()
    {
        var act1 = () => JsonSerializer
            .Deserialize<bool>(DispositionType.Inline.ToString().AddDoubleQuote(), _options);

        act1.Should().Throw<JsonException>();
    }
}
