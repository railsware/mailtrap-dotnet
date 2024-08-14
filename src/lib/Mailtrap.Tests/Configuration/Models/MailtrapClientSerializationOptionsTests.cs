// -----------------------------------------------------------------------
// <copyright file="MailtrapClientSerializationOptionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration.Models;


[TestFixture]
internal sealed class MailtrapClientSerializationOptionsTests
{
    [Test]
    public void Default_ShouldReturnValidDefaults()
    {
        MailtrapClientSerializationOptions.Default.PrettyJson.Should().BeFalse();
    }

    [Test]
    public void Constructor_ShouldInitValidDefaults()
    {
        new MailtrapClientSerializationOptions().PrettyJson.Should().BeFalse();
    }

    [Test]
    public void Setter_ShouldCorrectlyChangeField()
    {
        var options = MailtrapClientSerializationOptions.Default with
        {
            PrettyJson = true
        };

        options.PrettyJson.Should().BeTrue();
    }

    [Test]
    public void AsJsonSerializerOptions_ShouldProduceOptionsBasedOnDefault([Values(false, true)] bool prettyJson)
    {
        var options = new MailtrapClientSerializationOptions()
        {
            PrettyJson = prettyJson
        }.AsJsonSerializerOptions();

        var expected = new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = prettyJson
        };

        options.Should().BeEquivalentTo(expected);
    }
}
