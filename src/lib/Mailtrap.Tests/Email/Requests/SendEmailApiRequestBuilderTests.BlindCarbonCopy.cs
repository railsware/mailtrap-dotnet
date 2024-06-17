// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.BlindCarbonCopy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_BlindCarbonCopy
{
    private string RecipientEmail { get; } = "recipient@domain.com";
    private string RecipientDisplayName { get; } = "Recipient";
    private EmailParty _recipient1 { get; } = new("recipient1@domain.com", "Recipient 1");
    private EmailParty _recipient2 { get; } = new("recipient2@domain.com");



    #region WithBlindCopies

    [Test]
    public void WithBlindCopies_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithBlindCopies<RegularSendEmailApiRequest>(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBlindCopies_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopies(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBlindCopies_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopies(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void WithBlindCopies_ShouldAddRecipientsToCollection()
    {
        WithBlindCopies_CreateAndValidate(_recipient1, _recipient2);
    }

    [Test]
    public void WithBlindCopies_ShouldAddRecipientsToCollection_WhenCalledMultipleTimes()
    {
        var recipient3 = new EmailParty("recipient3@domain.com");
        var recipient4 = new EmailParty("recipient4@domain.com", "Recipient 4");

        var request = WithBlindCopies_CreateAndValidate(_recipient1, _recipient2);

        request.WithBlindCopies(recipient3, recipient4);

        request.BlindCarbonCopies.Should()
            .HaveCount(4).And
            .ContainInOrder(_recipient1, _recipient2, recipient3, recipient4);
    }

    [Test]
    public void WithBlindCopies_ShouldNotAddRecipientsToCollection_WhenParamsIsEmpty()
    {
        var request = WithBlindCopies_CreateAndValidate(_recipient1, _recipient2);

        request.WithBlindCopies([]);

        request.BlindCarbonCopies.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static RegularSendEmailApiRequest WithBlindCopies_CreateAndValidate(params EmailParty[] recipients)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithBlindCopies(recipients);

        request.BlindCarbonCopies.Should()
            .HaveCount(2).And
            .ContainInOrder(recipients);

        return request;
    }

    #endregion



    #region WithBlindCopy(recipient)

    [Test]
    public void WithBlindCopy_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithBlindCopy<RegularSendEmailApiRequest>(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBlindCopy_ShouldThrowArgumentNullException_WhenRecipientIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopy(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBlindCopy_ShouldAddRecipientToCollection()
    {
        WithBlindCopy_CreateAndValidate(_recipient1);
    }

    [Test]
    public void WithBlindCopy_ShouldAddRecipientToCollection_WhenCalledMultipleTimes()
    {
        var request = WithBlindCopy_CreateAndValidate(_recipient1);

        request.WithBlindCopy(_recipient2);

        request.BlindCarbonCopies.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static RegularSendEmailApiRequest WithBlindCopy_CreateAndValidate(EmailParty recipient)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithBlindCopy(recipient);

        request.BlindCarbonCopies.Should()
            .ContainSingle().And
            .Contain(recipient);

        return request;
    }

    #endregion



    #region WithBlindCopy(email, displayName)

    [Test]
    public void WithBlindCopy_ShouldThrowArgumentNullException_WhenRecipientEmailIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopy(request, null!, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBlindCopy_ShouldThrowArgumentNullException_WhenRecipientEmailIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopy(request, string.Empty, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBlindCopy_ShouldNotThrowException_WhenRecipientDisplayNameIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopy(request, RecipientEmail, null);

        act.Should().NotThrow();
    }

    [TestCase]
    public void WithBlindCopy_ShouldNotThrowException_WhenRecipientDisplayNameIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithBlindCopy(request, RecipientEmail, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithBlindCopy_ShouldAddRecipientToCollection_WhenOnlyEmailProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithBlindCopy(RecipientEmail);

        request.BlindCarbonCopies.Should().ContainSingle();

        var added = request.BlindCarbonCopies.First();
        added.EmailAddress.Should().Be(RecipientEmail);
        added.DisplayName.Should().BeNull();
    }

    [Test]
    public void WithBlindCopy_ShouldAddRecipientToCollection_WhenFullInfoProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithBlindCopy(RecipientEmail, RecipientDisplayName);

        request.BlindCarbonCopies.Should().ContainSingle();

        var added = request.BlindCarbonCopies.First();
        added.EmailAddress.Should().Be(RecipientEmail);
        added.DisplayName.Should().Be(RecipientDisplayName);
    }

    #endregion
}
