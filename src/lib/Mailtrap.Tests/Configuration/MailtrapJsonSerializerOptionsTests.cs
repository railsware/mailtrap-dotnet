// -----------------------------------------------------------------------
// <copyright file="MailtrapJsonSerializerOptionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration;


[TestFixture]
internal sealed class MailtrapJsonSerializerOptionsTests
{
    [Test]
    public void Default_ShouldContainProperValues()
    {
        var expected = new JsonSerializerOptions(JsonSerializerOptions.Default)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        MailtrapJsonSerializerOptions.Default.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NotIndented_ShouldContainProperValues()
    {
        var expected = new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = false
        };

        MailtrapJsonSerializerOptions.NotIndented.Should().BeEquivalentTo(expected);
    }
}
