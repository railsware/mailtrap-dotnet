// -----------------------------------------------------------------------
// <copyright file="ApiResponseTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Models;


[TestFixture]
internal sealed class ApiResponseTests
{
    [Test]
    public void ConstructorShouldProperlyInitializeProperties_WhenSuccess()
    {
        var response = new ApiResponse<string>(true);

        response.IsSuccess.Should().BeTrue();
        response.ErrorData.Should().BeNull();
    }

    [Test]
    public void ConstructorShouldProperlyInitializeProperties_WhenError()
    {
        var errorMessage = "Error";
        var response = new ApiResponse<string>(false, errorMessage);

        response.IsSuccess.Should().BeFalse();
        response.ErrorData.Should().Be(errorMessage);
    }
}
