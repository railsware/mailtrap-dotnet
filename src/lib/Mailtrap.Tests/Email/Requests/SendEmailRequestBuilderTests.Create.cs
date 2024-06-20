// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.Create.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_Create
{
    [Test]
    public void Create_ShouldReturnNewInstance_WhenCalled()
    {
        var result = SendEmailRequestBuilder.Email();

        result.Should()
            .NotBeNull().And
            .BeOfType<SendEmailRequest>();
    }
}
