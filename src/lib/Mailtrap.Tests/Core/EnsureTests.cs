// -----------------------------------------------------------------------
// <copyright file="EnsureTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Core;



[TestFixture]
internal sealed class EnsureTests
{
    [Test]
    public void NotNull_ShouldThrowArgumentNullException_WhenParamValueIsNull()
    {
        object? paramValue = null;

        var act = () => Ensure.NotNull(paramValue, nameof(paramValue));

        act.Should().Throw<ArgumentNullException>();
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

        var act = () => Ensure.NotNullOrEmpty(paramValue!, nameof(paramValue));

        act.Should().Throw<ArgumentNullException>();
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
