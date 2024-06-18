// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.TextBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_TextBody
{
    private string _text { get; } = "Some text";


    [Test]
    public void WithTextBody_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithTextBody<RegularSendEmailApiRequest>(null!, _text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithTextBody_ShouldNotThrowException_WhenTextIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTextBody(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithTextBody_ShouldNotThrowException_WhenTextIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTextBody(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithTextBody_ShouldAssignTextBodyProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithTextBody(_text);

        request.TextBody.Should().BeSameAs(_text);
    }

    [Test]
    public void WithTextBody_ShouldOverrideTextBody_WhenCalledSeveralTimes()
    {
        var otherText = "Updated Text";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithTextBody(_text)
            .WithTextBody(otherText);

        request.TextBody.Should().BeSameAs(otherText);
    }
}
