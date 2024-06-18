// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.TemplateVariables.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_TemplateVariables
{
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
            .WithTemplateVariables(_templateVars)
            .WithTemplateVariables(otherTemplateVariables);

        request.TemplateVariables.Should().BeSameAs(otherTemplateVariables);
    }
}
