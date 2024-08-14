// -----------------------------------------------------------------------
// <copyright file="MailtrapClientAuthenticationOptionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration.Models;


[TestFixture]
internal sealed class MailtrapClientAuthenticationOptionsTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenTokenIsNull()
    {
        var act = () => new MailtrapClientAuthenticationOptions(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldNotThrowException_WhenTokenIsEmpty()
    {
        var act = () => new MailtrapClientAuthenticationOptions(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Empty_ShouldReturnEmptyToken()
    {
        MailtrapClientAuthenticationOptions.Empty.ApiToken.Should().BeEmpty();
    }

    [Test]
    public void Empty_ShouldReturnNewObjectEveryTime_WhenCalled()
    {
        var options1 = MailtrapClientAuthenticationOptions.Empty;
        var options2 = MailtrapClientAuthenticationOptions.Empty;

        options1.Should().NotBeSameAs(options2);
    }

    [Test]
    public void Constructor_ShouldAssignTokenToProperty()
    {
        var token = "token";

        var options = new MailtrapClientAuthenticationOptions(token);

        options.ApiToken.Should().Be(token);
    }

    [Test]
    public void Copy_ShouldAssignTokenToProperty()
    {
        var token = "token";

        var options = MailtrapClientAuthenticationOptions.Empty with
        {
            ApiToken = token
        };

        options.ApiToken.Should().Be(token);
    }

    [Test]
    public void Equals_ShouldWorkProperly_WhenContainNonEmptyValue()
    {
        var token = "token";

        var options1 = new MailtrapClientAuthenticationOptions(token);
        var options2 = new MailtrapClientAuthenticationOptions(token);

        options1.Should().Be(options2);
        (options1 == options2).Should().BeTrue();
        options1.Equals(options2).Should().BeTrue();
        options1.GetHashCode().Should().Be(options2.GetHashCode());
    }

    [Test]
    public void Equals_ShouldWorkProperly_WhenContainEmptyValue()
    {
        var options1 = new MailtrapClientAuthenticationOptions(string.Empty);
        var options2 = MailtrapClientAuthenticationOptions.Empty;

        options1.Should().Be(options2);
        (options1 == options2).Should().BeTrue();
        options1.Equals(options2).Should().BeTrue();
        options1.GetHashCode().Should().Be(options2.GetHashCode());
    }

    [Test]
    public void Equals_ShouldWorkProperly_WhenContainDifferentValues()
    {
        var options1 = new MailtrapClientAuthenticationOptions("token1");
        var options2 = new MailtrapClientAuthenticationOptions("token2");

        options1.Should().NotBe(options2);
        (options1 == options2).Should().BeFalse();
        options1.Equals(options2).Should().BeFalse();
        options1.GetHashCode().Should().NotBe(options2.GetHashCode());
    }
}
