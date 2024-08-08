// -----------------------------------------------------------------------
// <copyright file="ValidationResultExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Extensions;


[TestFixture]
internal sealed class ValidationResultExtensionsTests
{
    private const string ParamName = "request";


    [Test]
    public void EnsureValidity_ShouldThrowArgumentNullException_WhenResultIsNull()
    {
        var act = () => ValidationResultExtensions.EnsureValidity(null!, ParamName);

        act.Should().Throw<ArgumentNullException>();
    }

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

        var act = () => result.EnsureValidity(ParamName);

        act.Should().Throw<ArgumentException>().WithParameterName(ParamName);
    }

    [Test]
    public void EnsureValidity_ShouldNotThrowException_WhenResultInvalid()
    {
        var result = new ValidationResult();

        var act = () => result.EnsureValidity(ParamName);

        act.Should().NotThrow();
    }
}
