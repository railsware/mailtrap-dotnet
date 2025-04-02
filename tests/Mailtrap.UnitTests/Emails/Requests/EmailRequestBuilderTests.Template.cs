namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(EmailRequestBuilder))]
internal sealed class EmailRequestBuilderTests_Template
{
    private string _templateId { get; } = "<ID>";


    [Test]
    public void Template_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => EmailRequestBuilder.Template<EmailRequest>(null!, _templateId);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Template_ShouldThrowArgumentNullException_WhenTemplateIdIsNull()
    {
        var request = EmailRequest.Create();

        var act = () => request.Template(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Template_ShouldThrowArgumentNullException_WhenTemplateIdIsEmpty()
    {
        var request = EmailRequest.Create();

        var act = () => request.Template(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Template_ShouldAssignTemplateProperly()
    {
        var request = EmailRequest
            .Create()
            .Template(_templateId);

        request.TemplateId.Should().BeSameAs(_templateId);
    }

    [Test]
    public void Template_ShouldOverrideTemplate_WhenCalledSeveralTimes()
    {
        var otherTemplate = "<ID2>";

        var request = EmailRequest
            .Create()
            .Template(_templateId)
            .Template(otherTemplate);

        request.TemplateId.Should().BeSameAs(otherTemplate);
    }
}
