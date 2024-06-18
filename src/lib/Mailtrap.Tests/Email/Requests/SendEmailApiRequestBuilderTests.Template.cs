// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Template.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Template
{
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
}
