// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Recipient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Recipient
{
    private string RecipientEmail { get; } = "recipient@domain.com";
    private string RecipientDisplayName { get; } = "Recipient";
    private EmailParty _recipient1 { get; } = new("recipient1@domain.com", "Recipient 1");
    private EmailParty _recipient2 { get; } = new("recipient2@domain.com");



    #region WithRecipients

    [Test]
    public void WithRecipients_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithRecipients<RegularSendEmailApiRequest>(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipients_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipients(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipients_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipients(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void WithRecipients_ShouldAddRecipientsToCollection()
    {
        WithRecipients_CreateAndValidate(_recipient1, _recipient2);
    }

    [Test]
    public void WithRecipients_ShouldAddRecipientsToCollection_WhenCalledMultipleTimes()
    {
        var recipient3 = new EmailParty("recipient3@domain.com");
        var recipient4 = new EmailParty("recipient4@domain.com", "Recipient 4");

        var request = WithRecipients_CreateAndValidate(_recipient1, _recipient2);

        request.WithRecipients(recipient3, recipient4);

        request.Recipients.Should()
            .HaveCount(4).And
            .ContainInOrder(_recipient1, _recipient2, recipient3, recipient4);
    }

    [Test]
    public void WithRecipients_ShouldNotAddRecipientsToCollection_WhenParamsIsEmpty()
    {
        var request = WithRecipients_CreateAndValidate(_recipient1, _recipient2);

        request.WithRecipients([]);

        request.Recipients.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static RegularSendEmailApiRequest WithRecipients_CreateAndValidate(params EmailParty[] recipients)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithRecipients(recipients);

        request.Recipients.Should()
            .HaveCount(2).And
            .ContainInOrder(recipients);

        return request;
    }

    #endregion



    #region WithRecipient(recipient)

    [Test]
    public void WithRecipient_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithRecipient<RegularSendEmailApiRequest>(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipient_ShouldThrowArgumentNullException_WhenRecipientIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipient(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipient_ShouldAddRecipientToCollection()
    {
        WithRecipient_CreateAndValidate(_recipient1);
    }

    [Test]
    public void WithRecipient_ShouldAddRecipientToCollection_WhenCalledMultipleTimes()
    {
        var request = WithRecipient_CreateAndValidate(_recipient1);

        request.WithRecipient(_recipient2);

        request.Recipients.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static RegularSendEmailApiRequest WithRecipient_CreateAndValidate(EmailParty recipient)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithRecipient(recipient);

        request.Recipients.Should()
            .ContainSingle().And
            .Contain(recipient);

        return request;
    }

    #endregion



    #region WithRecipient(email, displayName)
    [Test]
    public void WithRecipient_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipient<RegularSendEmailApiRequest>(null!, RecipientEmail);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipient_ShouldThrowArgumentNullException_WhenRecipientEmailIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipient(request, null!, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipient_ShouldThrowArgumentNullException_WhenRecipientEmailIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipient(request, string.Empty, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithRecipient_ShouldNotThrowException_WhenRecipientDisplayNameIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipient(request, RecipientEmail, null);

        act.Should().NotThrow();
    }

    [Test]
    public void WithRecipient_ShouldNotThrowException_WhenRecipientDisplayNameIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithRecipient(request, RecipientEmail, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithRecipient_ShouldAddRecipientToCollection_WhenOnlyEmailProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithRecipient(RecipientEmail);

        request.Recipients.Should().ContainSingle();

        var added = request.Recipients.First();
        added.EmailAddress.Should().Be(RecipientEmail);
        added.DisplayName.Should().BeNull();
    }

    [Test]
    public void WithRecipient_ShouldAddRecipientToCollection_WhenFullInfoProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithRecipient(RecipientEmail, RecipientDisplayName);

        request.Recipients.Should().ContainSingle();

        var added = request.Recipients.First();
        added.EmailAddress.Should().Be(RecipientEmail);
        added.DisplayName.Should().Be(RecipientDisplayName);
    }

    #endregion
}
