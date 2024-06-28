// -----------------------------------------------------------------------
// <copyright file="UriExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Extensions;


[TestFixture]
internal sealed class UriExtensionsTests
{
    private string _absoluteUrl { get; } = "https://example.com";
    private string _relativeUrl { get; } = "api/send";


    #region ToRelativeUri

    [Test]
    public void ToRelativeUri_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var act = () => UriExtensions.ToRelativeUri(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToRelativeUri_ShouldThrowArgumentNullException_WhenUriIsEmpty()
    {
        var act = () => UriExtensions.ToRelativeUri(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToRelativeUri_ShouldThrowArgumentException_WhenUriIsAbsolute()
    {
        var act = () => UriExtensions.ToRelativeUri(_absoluteUrl);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void ToRelativeUri_ShouldReturnUri_WhenUriIsRelative()
    {
        var uri = _relativeUrl.ToRelativeUri();

        uri.IsAbsoluteUri.Should().BeFalse();
        uri.ToString().Should().Be(_relativeUrl);
    }

    #endregion


    #region ToAbsoluteUri

    [Test]
    public void ToAbsoluteUri_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var act = () => UriExtensions.ToAbsoluteUri(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToAbsoluteUri_ShouldThrowArgumentNullException_WhenUriIsEmpty()
    {
        var act = () => UriExtensions.ToAbsoluteUri(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToAbsoluteUri_ShouldThrowArgumentException_WhenUriIsRelative()
    {
        var act = () => UriExtensions.ToAbsoluteUri(_relativeUrl);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void ToAbsoluteUri_ShouldReturnUri_WhenUriIsAbsolute()
    {
        var uri = _absoluteUrl.ToAbsoluteUri();

        uri.IsAbsoluteUri.Should().BeTrue();
        uri.ToString().Should().Be(_absoluteUrl + "/");
    }

    #endregion



    #region ToUri

    [Test]
    public void ToUri_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var act = () => UriExtensions.ToUri(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToUri_ShouldThrowArgumentNullException_WhenUriIsEmpty()
    {
        var act = () => UriExtensions.ToUri(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToUri_ShouldNotThrowException_WhenUriIsRelative()
    {
        var act = () => UriExtensions.ToUri(_relativeUrl);

        act.Should().NotThrow();
    }

    [Test]
    public void ToUri_ShouldNotThrowException_WhenUriIsAbsolute()
    {
        var act = () => UriExtensions.ToUri(_absoluteUrl);

        act.Should().NotThrow();
    }

    [Test]
    public void ToUri_ShouldReturnUri_WhenUriIsRelative()
    {
        var uri = _relativeUrl.ToUri();

        uri.IsAbsoluteUri.Should().BeFalse();
        uri.ToString().Should().Be(_relativeUrl);
    }

    [Test]
    public void ToUri_ShouldReturnUri_WhenUriIsAbsolute()
    {
        var uri = _absoluteUrl.ToUri();

        uri.IsAbsoluteUri.Should().BeTrue();
        uri.ToString().Should().Be(_absoluteUrl + "/");
    }

    #endregion
}
