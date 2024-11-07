// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.TemplateVariables.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_TemplateVariables
{
    private object _templateVars { get; } = new();


    [Test]
    public void TemplateVariables_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.TemplateVariables(null!, _templateVars);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TemplateVariables_ShouldNotThrowException_WhenTemplateVariablesIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.TemplateVariables(null);

        act.Should().NotThrow();
    }

    [Test]
    public void TemplateVariables_ShouldAssignTemplateVariablesProperly()
    {
        var request = SendEmailRequest
            .Create()
            .TemplateVariables(_templateVars);

        request.TemplateVariables.Should().BeSameAs(_templateVars);
    }

    [Test]
    public void TemplateVariables_ShouldOverrideTemplateVariables_WhenCalledSeveralTimes()
    {
        var otherTemplateVariables = new object();

        var request = SendEmailRequest
            .Create()
            .TemplateVariables(_templateVars)
            .TemplateVariables(otherTemplateVariables);

        request.TemplateVariables.Should().BeSameAs(otherTemplateVariables);
    }
}
