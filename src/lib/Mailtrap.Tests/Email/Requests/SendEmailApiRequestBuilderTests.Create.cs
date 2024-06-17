// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Create.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Create
{
    [Test]
    public void Create_ShouldReturnNewInstance_WhenCalled()
    {
        var result = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        result.Should()
            .NotBeNull().And
            .BeOfType<RegularSendEmailApiRequest>();
    }
}
