// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Sender.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class SendEmailApiRequestBuilderTests_Sender
{
    private const string SenderEmail = "sender@domain.com";
    private const string SenderDisplayName = "Sender";
    private readonly EmailParty _sender = new(SenderEmail, SenderDisplayName);


    #region WithSender(sender)

    [Test]
    public void WithSender_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithSender<RegularSendEmailApiRequest>(null!, _sender);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSender_ShouldThrowArgumentNullException_WhenSenderIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSender(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSender_ShouldAssignSenderProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender(_sender);

        request.Sender.Should().BeSameAs(_sender);
    }

    [Test]
    public void WithSender_ShouldOverrideSender_WhenCalledSeveralTimes()
    {
        var otherSender = new EmailParty("sender2@domain.com", "Sender 2");

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender(_sender)
            .WithSender(otherSender);

        request.Sender.Should().BeSameAs(otherSender);
    }

    #endregion


    #region WithSender(email, displayName)

    [Test]
    public void WithSender_ShouldThrowArgumentNullException_WhenSenderEmailIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSender(request, null!, SenderDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSender_ShouldThrowArgumentNullException_WhenSenderEmailIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSender(request, string.Empty, SenderDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithSender_ShouldNotThrowException_WhenSenderDisplayNameIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSender(request, SenderEmail, null);

        act.Should().NotThrow();
    }

    [Test]
    public void WithSender_ShouldNotThrowException_WhenSenderDisplayNameIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithSender(request, SenderEmail, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithSender_ShouldInitializeSenderProperly_WhenOnlyEmailProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender(SenderEmail);

        request.Sender.Should().NotBeNull();
        request.Sender!.EmailAddress.Should().Be(SenderEmail);
        request.Sender!.DisplayName.Should().BeNull();
    }

    [Test]
    public void WithSender_ShouldInitializeSenderProperly_WhenFullInfoProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender(SenderEmail, SenderDisplayName);

        request.Sender.Should().NotBeNull();
        request.Sender!.EmailAddress.Should().Be(SenderEmail);
        request.Sender!.DisplayName.Should().Be(SenderDisplayName);
    }

    [Test]
    public void WithSender_ShouldOverrideSender_WhenCalledSeveralTimes_2()
    {
        var otherSenderEmail = "sender2@domain.com";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender(_sender)
            .WithSender(otherSenderEmail);

        request.Sender.Should().NotBeSameAs(_sender);
        request.Sender!.EmailAddress.Should().Be(otherSenderEmail);
        request.Sender!.DisplayName.Should().BeNull();
    }

    #endregion
}
