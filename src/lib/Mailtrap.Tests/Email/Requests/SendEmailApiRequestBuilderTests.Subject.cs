// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Subject.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Subject
{
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
}
