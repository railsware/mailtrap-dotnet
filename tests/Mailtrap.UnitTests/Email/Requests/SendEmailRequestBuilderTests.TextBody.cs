// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.TextBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Email.Requests;


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
        var request = SendEmailRequest.Create();

        var act = () => request.Text(null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Text_ShouldNotThrowException_WhenTextIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.Text(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Text_ShouldAssignTextBodyProperly()
    {
        var request = SendEmailRequest
            .Create()
            .Text(_text);

        request.TextBody.Should().BeSameAs(_text);
    }

    [Test]
    public void Text_ShouldOverrideTextBody_WhenCalledSeveralTimes()
    {
        var otherText = "Updated Text";

        var request = SendEmailRequest
            .Create()
            .Text(_text)
            .Text(otherText);

        request.TextBody.Should().BeSameAs(otherText);
    }
}
