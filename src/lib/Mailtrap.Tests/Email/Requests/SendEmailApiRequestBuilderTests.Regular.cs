// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Subject.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Regular
{
    #region Subject

    private string _subject { get; } = "Subject";


    [Test]
    public void WithSubject_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithSubject<RegularSendEmailApiRequest>(null!, _subject);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSubject_ShouldThrowArgumentNullException_WhenSubjectIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSubject(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSubject_ShouldThrowArgumentNullException_WhenSubjectIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSubject(request, string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSubject_ShouldAssignSubjectProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSubject(_subject);

        request.Subject.Should().BeSameAs(_subject);
    }

    [Test]
    public void WithSubject_ShouldOverrideSubject_WhenCalledSeveralTimes()
    {
        var otherSubject = "Updated subject";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSubject(_subject)
            .WithSubject(otherSubject);

        request.Subject.Should().BeSameAs(otherSubject);
    }

    #endregion


    #region Category

    private string _category { get; } = "Category";


    [Test]
    public void WithCategory_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithCategory<RegularSendEmailApiRequest>(null!, _category);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCategory_ShouldNotThrowException_WhenCategoryIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCategory(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCategory_ShouldNotThrowException_WhenCategoryIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCategory(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCategory_ShouldAssignCategoryProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCategory(_category);

        request.Category.Should().BeSameAs(_category);
    }

    [Test]
    public void WithCategory_ShouldOverrideCategory_WhenCalledSeveralTimes()
    {
        var otherCategory = "Updated Category";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCategory(_category)
            .WithCategory(otherCategory);

        request.Category.Should().BeSameAs(otherCategory);
    }

    #endregion


    #region TextBody

    private string _text { get; } = "Some text";


    [Test]
    public void WithTextBody_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithTextBody<RegularSendEmailApiRequest>(null!, _text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithTextBody_ShouldNotThrowException_WhenTextIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTextBody(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithTextBody_ShouldNotThrowException_WhenTextIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithTextBody(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithTextBody_ShouldAssignTextBodyProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithTextBody(_text);

        request.TextBody.Should().BeSameAs(_text);
    }

    [Test]
    public void WithTextBody_ShouldOverrideTextBody_WhenCalledSeveralTimes()
    {
        var otherText = "Updated Text";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithTextBody(_text)
            .WithTextBody(otherText);

        request.TextBody.Should().BeSameAs(otherText);
    }

    #endregion


    #region HtmlBody

    private string _html { get; } = "<h1>Header</h1><p>Greetings!</p>";


    [Test]
    public void WithHtmlBody_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithHtmlBody<RegularSendEmailApiRequest>(null!, _html);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHtmlBody_ShouldNotThrowException_WhenSubjectIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHtmlBody(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHtmlBody_ShouldNotThrowException_WhenSubjectIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHtmlBody(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHtmlBody_ShouldAssignCategoryProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHtmlBody(_html);

        request.HtmlBody.Should().BeSameAs(_html);
    }

    [Test]
    public void WithHtmlBody_ShouldOverrideCategory_WhenCalledSeveralTimes()
    {
        var otherHtml = "<h2>Header</h2><p>Congratulation!</p>";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHtmlBody(_html)
            .WithHtmlBody(otherHtml);

        request.HtmlBody.Should().BeSameAs(otherHtml);
    }

    #endregion
}
