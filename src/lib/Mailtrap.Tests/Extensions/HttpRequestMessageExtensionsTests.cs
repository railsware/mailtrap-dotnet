// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Extensions;


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



    #region ConfigureApiAuthenticationHeader

    private string _apiToken { get; } = "token";

    [Test]
    public void ConfigureApiAuthenticationHeader_ShouldThrowArgumentNullException_WhenMessageIsNull()
    {
        var act = () => HttpRequestMessageExtensions.ConfigureApiAuthenticationHeader(null!, _apiToken);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConfigureApiAuthenticationHeader_ShouldApplyHeader_WhenWasUnspecified()
    {
        using var message = new HttpRequestMessage();

        message.ConfigureApiAuthenticationHeader(_apiToken);

        message.Headers.Should().ContainKey(HeaderNames.ApiKeyHeader);
        message.Headers.GetValues(HeaderNames.ApiKeyHeader).Should().ContainSingle(m => m == _apiToken);
    }

    [Test]
    public void ConfigureApiAuthenticationHeader_ShouldOverrideHeader_WhenWasSpecified()
    {
        using var message = new HttpRequestMessage();

        message.Headers.Add(HeaderNames.ApiKeyHeader, "other token");

        message.ConfigureApiAuthenticationHeader(_apiToken);

        message.Headers.GetValues(HeaderNames.ApiKeyHeader).Should().ContainSingle(m => m == _apiToken);
    }

    #endregion
}
