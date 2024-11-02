// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.Template.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_Template
{
    private string _templateId { get; } = "<ID>";


    [Test]
    public void Template_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.Template(null!, _templateId);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Template_ShouldThrowArgumentNullException_WhenTemplateIdIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.Template(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Template_ShouldThrowArgumentNullException_WhenTemplateIdIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.Template(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Template_ShouldAssignTemplateProperly()
    {
        var request = SendEmailRequest
            .Create()
            .Template(_templateId);

        request.TemplateId.Should().BeSameAs(_templateId);
    }

    [Test]
    public void Template_ShouldOverrideTemplate_WhenCalledSeveralTimes()
    {
        var otherTemplate = "<ID2>";

        var request = SendEmailRequest
            .Create()
            .Template(_templateId)
            .Template(otherTemplate);

        request.TemplateId.Should().BeSameAs(otherTemplate);
    }
}
