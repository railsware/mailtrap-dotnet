// -----------------------------------------------------------------------
// <copyright file="EnsureTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Extensions;


[TestFixture]
internal sealed class EnsureTests
{
    [Test]
    public void NotNull_ShouldThrowArgumentNullException_WhenParamValueIsNull()
    {
        object? paramValue = null;
        var message = "Message";

        var act = () => Ensure.NotNull(paramValue, nameof(paramValue), message);

        act.Should().Throw<ArgumentNullException>().WithMessage(message + "*");
    }

    [Test]
    public void NotNull_ShouldNotThrowException_WhenParamValueIsNotNull()
    {
        var paramValue = new object();

        var act = () => Ensure.NotNull(paramValue, nameof(paramValue));

        act.Should().NotThrow<ArgumentNullException>();
    }

    [Test]
    public void NotNullOrEmpty_ShouldThrowArgumentNullException_WhenParamValueIsNull()
    {
        string? paramValue = null;
        var message = "Message";

        var act = () => Ensure.NotNullOrEmpty(paramValue!, nameof(paramValue), message);

        act.Should().Throw<ArgumentNullException>().WithMessage(message + "*");
    }

    [Test]
    public void NotNullOrEmpty_ShouldThrowArgumentNullException_WhenParamValueIsEmpty()
    {
        var paramValue = string.Empty;

        var act = () => Ensure.NotNullOrEmpty(paramValue, nameof(paramValue));

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void NotNullOrEmpty_ShouldNotThrowException_WhenParamValueIsNotNullOrEmpty()
    {
        var paramValue = "paramValue";

        var act = () => Ensure.NotNullOrEmpty(paramValue, nameof(paramValue));

        act.Should().NotThrow<ArgumentNullException>();
    }
}
