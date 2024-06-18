// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.HtmlBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_HtmlBody
{
    private string _html { get; } = "<h1>Header</h1><p>Greetings!</p>";


    [Test]
    public void WithHtmlBody_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithHtmlBody<RegularSendEmailApiRequest>(null!, _html);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHtmlBody_ShouldNotThrowException_WhenSubjectIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHtmlBody(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHtmlBody_ShouldNotThrowException_WhenSubjectIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHtmlBody(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHtmlBody_ShouldAssignCategoryProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHtmlBody(_html);

        request.HtmlBody.Should().BeSameAs(_html);
    }

    [Test]
    public void WithHtmlBody_ShouldOverrideCategory_WhenCalledSeveralTimes()
    {
        var otherHtml = "<h2>Header</h2><p>Congratulation!</p>";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHtmlBody(_html)
            .WithHtmlBody(otherHtml);

        request.HtmlBody.Should().BeSameAs(otherHtml);
    }
}
