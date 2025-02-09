// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.HtmlBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_HtmlBody
{
    private string _html { get; } = "<h1>Header</h1><p>Greetings!</p>";


    [Test]
    public void Html_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.Html(null!, _html);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Html_ShouldNotThrowException_WhenHtmlIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.Html(null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Html_ShouldNotThrowException_WhenHtmlIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.Html(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Html_ShouldAssignHtmlBodyProperly()
    {
        var request = SendEmailRequest
            .Create()
            .Html(_html);

        request.HtmlBody.Should().BeSameAs(_html);
    }

    [Test]
    public void Html_ShouldOverrideHtmlBody_WhenCalledSeveralTimes()
    {
        var otherHtml = "<h2>Header</h2><p>Congratulation!</p>";

        var request = SendEmailRequest
            .Create()
            .Html(_html)
            .Html(otherHtml);

        request.HtmlBody.Should().BeSameAs(otherHtml);
    }
}
