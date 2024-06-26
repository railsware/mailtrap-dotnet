// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.HtmlBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


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
        var request = SendEmailRequestBuilder.Email();

        var act = () => SendEmailRequestBuilder.Html(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Html_ShouldNotThrowException_WhenHtmlIsEmpty()
    {
        var request = SendEmailRequestBuilder.Email();

        var act = () => SendEmailRequestBuilder.Html(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Html_ShouldAssignHtmlBodyProperly()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Html(_html);

        request.HtmlBody.Should().BeSameAs(_html);
    }

    [Test]
    public void Html_ShouldOverrideHtmlBody_WhenCalledSeveralTimes()
    {
        var otherHtml = "<h2>Header</h2><p>Congratulation!</p>";

        var request = SendEmailRequestBuilder
            .Email()
            .Html(_html)
            .Html(otherHtml);

        request.HtmlBody.Should().BeSameAs(otherHtml);
    }
}
