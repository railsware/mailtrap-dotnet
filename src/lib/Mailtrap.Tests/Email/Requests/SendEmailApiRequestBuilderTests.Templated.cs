// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Templated.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Templated
{
    #region TemplateId

    private string _templateId { get; } = "<ID>";


    [Test]
    public void WithTemplate_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithTemplate<TemplatedSendEmailApiRequest>(null!, _templateId);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithTemplate_ShouldThrowArgumentNullException_WhenTemplateIdIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<TemplatedSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTemplate(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithTemplate_ShouldThrowArgumentNullException_WhenTemplateIdIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<TemplatedSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTemplate(request, string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithTemplate_ShouldAssignTemplateProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<TemplatedSendEmailApiRequest>()
            .WithTemplate(_templateId);

        request.TemplateId.Should().BeSameAs(_templateId);
    }

    [Test]
    public void WithTemplate_ShouldOverrideTemplate_WhenCalledSeveralTimes()
    {
        var otherTemplate = "<ID2>";

        var request = SendEmailApiRequestBuilder
            .Create<TemplatedSendEmailApiRequest>()
            .WithTemplate(_templateId)
            .WithTemplate(otherTemplate);

        request.TemplateId.Should().BeSameAs(otherTemplate);
    }

    #endregion


    #region TemplateVariables

    private object _templateVars { get; } = new();


    [Test]
    public void WithTemplateVariables_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithTemplateVariables<TemplatedSendEmailApiRequest>(null!, _templateVars);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithTemplateVariables_ShouldNotThrowException_WhenTemplateVariablesIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<TemplatedSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTemplateVariables(request, null);

        act.Should().NotThrow();
    }

    [Test]
    public void WithTemplateVariables_ShouldAssignTemplateVariablesProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<TemplatedSendEmailApiRequest>()
            .WithTemplateVariables(_templateVars);

        request.TemplateVariables.Should().BeSameAs(_templateVars);
    }

    [Test]
    public void WithTemplateVariables_ShouldOverrideTemplateVariables_WhenCalledSeveralTimes()
    {
        var otherTemplateVariables = new object();

        var request = SendEmailApiRequestBuilder
            .Create<TemplatedSendEmailApiRequest>()
            .WithTemplateVariables(_templateId)
            .WithTemplateVariables(otherTemplateVariables);

        request.TemplateVariables.Should().BeSameAs(otherTemplateVariables);
    }

    #endregion
}
