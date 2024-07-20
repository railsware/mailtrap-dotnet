// -----------------------------------------------------------------------
// <copyright file="ValidationResultExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Extensions;


[TestFixture]
internal sealed class ValidationResultExtensionsTests
{
    [Test]
    public void EnsureValidity_ShouldThrowArgumentException_WhenResultIsInvalid()
    {
        var result = new ValidationResult
        {
            Errors =
            [
                new("Property", "Error")
            ]
        };
        var paramName = "request";

        var act = () => result.EnsureValidity(paramName);

        act.Should().Throw<ArgumentException>().WithParameterName(paramName);
    }

    [Test]
    public void EnsureValidity_ShouldNotThrowException_WhenResultInvalid()
    {
        var result = new ValidationResult();
        var paramName = "request";

        var act = () => result.EnsureValidity(paramName);

        act.Should().NotThrow<ArgumentException>();
    }
}
