namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(EmailRequestBuilder))]
internal sealed class EmailRequestBuilderTests_HtmlBody
{
    private string _html { get; } = "<h1>Header</h1><p>Greetings!</p>";


    [Test]
    public void Html_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => EmailRequestBuilder.Html<EmailRequest>(null!, _html);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Html_ShouldNotThrowException_WhenHtmlIsNull()
    {
        var request = EmailRequest.Create();

        var act = () => request.Html(null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Html_ShouldNotThrowException_WhenHtmlIsEmpty()
    {
        var request = EmailRequest.Create();

        var act = () => request.Html(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Html_ShouldAssignHtmlBodyProperly()
    {
        var request = EmailRequest
            .Create()
            .Html(_html);

        request.HtmlBody.Should().BeSameAs(_html);
    }

    [Test]
    public void Html_ShouldOverrideHtmlBody_WhenCalledSeveralTimes()
    {
        var otherHtml = "<h2>Header</h2><p>Congratulation!</p>";

        var request = EmailRequest
            .Create()
            .Html(_html)
            .Html(otherHtml);

        request.HtmlBody.Should().BeSameAs(otherHtml);
    }
}
