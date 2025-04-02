namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(EmailRequestBuilder))]
internal sealed class EmailRequestBuilderTests_TemplateVariables
{
    private object _templateVars { get; } = new();


    [Test]
    public void TemplateVariables_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => EmailRequestBuilder.TemplateVariables<EmailRequest>(null!, _templateVars);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TemplateVariables_ShouldNotThrowException_WhenTemplateVariablesIsNull()
    {
        var request = EmailRequest.Create();

        var act = () => request.TemplateVariables(null);

        act.Should().NotThrow();
    }

    [Test]
    public void TemplateVariables_ShouldAssignTemplateVariablesProperly()
    {
        var request = EmailRequest
            .Create()
            .TemplateVariables(_templateVars);

        request.TemplateVariables.Should().BeSameAs(_templateVars);
    }

    [Test]
    public void TemplateVariables_ShouldOverrideTemplateVariables_WhenCalledSeveralTimes()
    {
        var otherTemplateVariables = new object();

        var request = EmailRequest
            .Create()
            .TemplateVariables(_templateVars)
            .TemplateVariables(otherTemplateVariables);

        request.TemplateVariables.Should().BeSameAs(otherTemplateVariables);
    }
}
