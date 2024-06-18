// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.CarbonCopy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_CarbonCopy
{
    private string RecipientEmail { get; } = "recipient@domain.com";
    private string RecipientDisplayName { get; } = "Recipient";
    private EmailParty _recipient1 { get; } = new("recipient1@domain.com", "Recipient 1");
    private EmailParty _recipient2 { get; } = new("recipient2@domain.com");



    #region WithCopies

    [Test]
    public void WithCopies_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithCopies<RegularSendEmailApiRequest>(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopies_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopies(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopies_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopies(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCopies_ShouldAddRecipientsToCollection()
    {
        WithCopies_CreateAndValidate(_recipient1, _recipient2);
    }

    [Test]
    public void WithCopies_ShouldAddRecipientsToCollection_WhenCalledMultipleTimes()
    {
        var recipient3 = new EmailParty("recipient3@domain.com");
        var recipient4 = new EmailParty("recipient4@domain.com", "Recipient 4");

        var request = WithCopies_CreateAndValidate(_recipient1, _recipient2);

        request.WithCopies(recipient3, recipient4);

        request.CarbonCopies.Should()
            .HaveCount(4).And
            .ContainInOrder(_recipient1, _recipient2, recipient3, recipient4);
    }

    [Test]
    public void WithCopies_ShouldNotAddRecipientsToCollection_WhenParamsIsEmpty()
    {
        var request = WithCopies_CreateAndValidate(_recipient1, _recipient2);

        request.WithCopies([]);

        request.CarbonCopies.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static RegularSendEmailApiRequest WithCopies_CreateAndValidate(params EmailParty[] recipients)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCopies(recipients);

        request.CarbonCopies.Should()
            .HaveCount(2).And
            .ContainInOrder(recipients);

        return request;
    }

    #endregion



    #region WithCopy(recipient)

    [Test]
    public void WithCopy_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithCopy<RegularSendEmailApiRequest>(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopy_ShouldThrowArgumentNullException_WhenRecipientIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopy(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopy_ShouldAddRecipientToCollection()
    {
        WithCopy_CreateAndValidate(_recipient1);
    }

    [Test]
    public void WithCopy_ShouldAddRecipientToCollection_WhenCalledMultipleTimes()
    {
        var request = WithCopy_CreateAndValidate(_recipient1);

        request.WithCopy(_recipient2);

        request.CarbonCopies.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static RegularSendEmailApiRequest WithCopy_CreateAndValidate(EmailParty recipient)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCopy(recipient);

        request.CarbonCopies.Should()
            .ContainSingle().And
            .Contain(recipient);

        return request;
    }

    #endregion



    #region WithCopy(email, displayName)

    [Test]
    public void WithCopy_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopy<RegularSendEmailApiRequest>(null!, RecipientEmail);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopy_ShouldThrowArgumentNullException_WhenRecipientEmailIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopy(request, null!, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopy_ShouldThrowArgumentNullException_WhenRecipientEmailIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopy(request, string.Empty, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCopy_ShouldNotThrowException_WhenRecipientDisplayNameIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopy(request, RecipientEmail, null);

        act.Should().NotThrow();
    }

    [TestCase]
    public void WithCopy_ShouldNotThrowException_WhenRecipientDisplayNameIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCopy(request, RecipientEmail, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCopy_ShouldAddRecipientToCollection_WhenOnlyEmailProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCopy(RecipientEmail);

        request.CarbonCopies.Should().ContainSingle();

        var added = request.CarbonCopies.First();
        added.EmailAddress.Should().Be(RecipientEmail);
        added.DisplayName.Should().BeNull();
    }

    [Test]
    public void WithCopy_ShouldAddRecipientToCollection_WhenFullInfoProvided()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCopy(RecipientEmail, RecipientDisplayName);

        request.CarbonCopies.Should().ContainSingle();

        var added = request.CarbonCopies.First();
        added.EmailAddress.Should().Be(RecipientEmail);
        added.DisplayName.Should().Be(RecipientDisplayName);
    }

    #endregion
}
