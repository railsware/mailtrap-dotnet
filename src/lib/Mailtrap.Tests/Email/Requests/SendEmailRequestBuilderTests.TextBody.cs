// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.TextBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_TextBody
{
    private string _text { get; } = "Some text";


    [Test]
    public void Text_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.Text(null!, _text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Text_ShouldNotThrowException_WhenTextIsNull()
    {
        var request = SendEmailRequestBuilder.Email();

        var act = () => SendEmailRequestBuilder.Text(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Text_ShouldNotThrowException_WhenTextIsEmpty()
    {
        var request = SendEmailRequestBuilder.Email();

        var act = () => SendEmailRequestBuilder.Text(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Text_ShouldAssignTextBodyProperly()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Text(_text);

        request.TextBody.Should().BeSameAs(_text);
    }

    [Test]
    public void Text_ShouldOverrideTextBody_WhenCalledSeveralTimes()
    {
        var otherText = "Updated Text";

        var request = SendEmailRequestBuilder
            .Email()
            .Text(_text)
            .Text(otherText);

        request.TextBody.Should().BeSameAs(otherText);
    }
}
