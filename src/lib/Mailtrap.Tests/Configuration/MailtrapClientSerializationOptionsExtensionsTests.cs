// -----------------------------------------------------------------------
// <copyright file="MailtrapClientSerializationOptionsExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration;


[TestFixture]
internal sealed class MailtrapClientSerializationOptionsExtensionsTests
{
    [Test]
    public void ToJsonSerializerOptions_ShouldThrowArgumentNullException_WhenOptionsAreNull()
    {
        MailtrapClientSerializationOptions? options = null;

        var act = () => options!.ToJsonSerializerOptions();

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToJsonSerializerOptions_ShouldProduceOptionsBasedOnDefault([Values(false, true)] bool prettyJson)
    {
        var options = new MailtrapClientSerializationOptions()
        {
            PrettyJson = prettyJson
        }.ToJsonSerializerOptions();

        var expected = new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = prettyJson
        };

        options.Should().BeEquivalentTo(expected);
    }
}
