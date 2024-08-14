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
        var options = MailtrapClientSerializationOptions.Default;

        options.PrettyJson.Should().BeFalse();
    }

    [Test]
    public void Default_ShouldReturnNewObjectEveryTime_WhenCalled()
    {
        var options1 = MailtrapClientSerializationOptions.Default;
        var options2 = MailtrapClientSerializationOptions.Default;

        options1.Should().NotBeSameAs(options2);
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
