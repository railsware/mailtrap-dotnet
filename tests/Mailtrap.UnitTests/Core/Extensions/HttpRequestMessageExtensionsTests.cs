namespace Mailtrap.UnitTests.Core.Extensions;


[TestFixture]
internal sealed class HttpRequestMessageExtensionsTests
{
    #region ConfigureAcceptHeader

    [Test]
    public void ConfigureAcceptHeader_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        var act = () => HttpRequestMessageExtensions.ConfigureAcceptHeader(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConfigureAcceptHeader_ShouldApplyAcceptHeader_WhenNoHeadersSpecified()
    {
        using var message = new HttpRequestMessage();

        message.ConfigureAcceptHeader();

        message.Headers.Accept.Should().ContainSingle(m => m.MediaType == MimeTypes.Application.Json);
    }

    [Test]
    public void ConfigureAcceptHeader_ShouldOverrideAcceptHeader_WhenOthersWereSpecified()
    {
        using var message = new HttpRequestMessage();

        message.Headers.Accept.Add(new(MediaTypeNames.Text.Plain));
        message.Headers.Accept.Add(new(MediaTypeNames.Text.Html));

        message.ConfigureAcceptHeader();

        message.Headers.Accept.Should().ContainSingle(m => m.MediaType == MimeTypes.Application.Json);
    }

    #endregion



    #region ConfigureUserAgentHeader

    [Test]
    public void ConfigureUserAgentHeader_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        var act = () => HttpRequestMessageExtensions.ConfigureUserAgentHeader(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConfigureUserAgentHeader_ShouldApplyUserAgentHeader_WhenNoHeadersSpecified()
    {
        using var message = new HttpRequestMessage();

        message.ConfigureUserAgentHeader();

        message.Headers.UserAgent.Should().ContainSingle(m =>
            m.Product!.Name == HeaderValuesTestConstants.UserAgentName &&
            m.Product!.Version == HeaderValues.UserAgentVersion);
    }

    [Test]
    public void ConfigureUserAgentHeader_ShouldOverrideUserAgentHeader_WhenOthersWereSpecified()
    {
        using var message = new HttpRequestMessage();

        message.Headers.UserAgent.Add(new("explorer", "1.0"));
        message.Headers.UserAgent.Add(new("gecko", "4.0"));

        message.ConfigureUserAgentHeader();

        message.Headers.UserAgent.Should().ContainSingle(m =>
            m.Product!.Name == HeaderValuesTestConstants.UserAgentName &&
            m.Product!.Version == HeaderValues.UserAgentVersion);
    }

    #endregion



    #region ConfigureAuthorizationHeader

    private string _apiToken { get; } = "token";

    [Test]
    public void ConfigureAuthorizationHeader_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        var act = () => HttpRequestMessageExtensions.ConfigureAuthorizationHeader(null!, _apiToken);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConfigureAuthorizationHeader_ShouldApplyHeader_WhenWasUnspecified()
    {
        using var message = new HttpRequestMessage();

        message.ConfigureAuthorizationHeader(_apiToken);

        message.Headers.Authorization.Should()
            .NotBeNull().And
            .BeEquivalentTo(new AuthenticationHeaderValue("Bearer", _apiToken));
    }

    [Test]
    public void ConfigureAuthorizationHeader_ShouldOverrideHeader_WhenWasSpecified()
    {
        using var message = new HttpRequestMessage();

        message.Headers.Authorization = new("other_scheme", "other_token");

        message.ConfigureAuthorizationHeader(_apiToken);

        message.Headers.Authorization.Should()
            .BeEquivalentTo(new AuthenticationHeaderValue("Bearer", _apiToken));
    }

    #endregion
}
