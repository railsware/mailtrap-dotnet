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

    [Test]
    public void Deserialize_ShouldThrow_WhenInvalidTypeSpecified()
    {
        var act1 = () => JsonSerializer
            .Deserialize<bool>(DispositionType.Inline.ToString().Quoted(), _options);

        act1.Should().Throw<JsonException>();
    }
}
