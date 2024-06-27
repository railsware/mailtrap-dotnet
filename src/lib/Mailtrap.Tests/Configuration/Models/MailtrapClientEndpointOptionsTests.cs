// -----------------------------------------------------------------------
// <copyright file="MailtrapClientEndpointOptionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration.Models;


[TestFixture]
internal sealed class MailtrapClientEndpointOptionsTests
{
    private Uri _uri { get; } = new("https://domain.com");
    private string _httpClientName { get; } = "bulk";



    #region Defaults

    [Test]
    public void Defaults_ShouldReturnValidDefaults()
    {
        MailtrapClientEndpointOptions.SendDefault.BaseUrl.Should().Be(Endpoints.SendDefaultUrl);
        MailtrapClientEndpointOptions.BulkDefault.BaseUrl.Should().Be(Endpoints.BulkDefaultUrl);
        MailtrapClientEndpointOptions.TestDefault.BaseUrl.Should().Be(Endpoints.TestDefaultUrl);
    }

    #endregion


    #region Constructor(Uri)

    [Test]
    public void ConstructorWithUri_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        Uri? uri = null;

        var act = () => new MailtrapClientEndpointOptions(uri!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConstructorWithUri_ShouldNotThrowException_WhenUriIsValid()
    {
        var act = () => new MailtrapClientEndpointOptions(_uri);

        act.Should().NotThrow();
    }

    [Test]
    public void ConstructorWithUri_ShouldDefaultHttpClientToNull_WhenNotSpecified()
    {
        var options = new MailtrapClientEndpointOptions(_uri);

        options.HttpClientName.Should().BeNull();
    }

    [Test]
    public void ConstructorWithUri_ShouldAssignPropertiesCorrectly()
    {
        var options = new MailtrapClientEndpointOptions(_uri, _httpClientName);

        options.BaseUrl.Should().Be(_uri);
        options.HttpClientName.Should().Be(_httpClientName);
    }

    #endregion



    #region Constructor(string)

    [Test]
    public void ConstructorWithString_ShouldThrowArgumentNullException_WhenStringIsNull()
    {
        string? uri = null;

        var act = () => new MailtrapClientEndpointOptions(uri!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConstructorWithString_ShouldThrowArgumentException_WhenStringIsNotValidAbsoluteUri()
    {
        var act = () => new MailtrapClientEndpointOptions("/api/send");

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void ConstructorWithString_ShouldNotThrowException_WhenUriIsValid()
    {
        var act = () => new MailtrapClientEndpointOptions(_uri.ToString());

        act.Should().NotThrow();
    }

    [Test]
    public void ConstructorWithString_ShouldDefaultHttpClientToNull_WhenNotSpecified()
    {
        var options = new MailtrapClientEndpointOptions(_uri.ToString());

        options.HttpClientName.Should().BeNull();
    }

    [Test]
    public void ConstructorWithString_ShouldAssignPropertiesCorrectly()
    {
        var options = new MailtrapClientEndpointOptions(_uri.ToString(), _httpClientName);

        options.BaseUrl.Should().Be(_uri);
        options.HttpClientName.Should().Be(_httpClientName);
    }

    #endregion
}
