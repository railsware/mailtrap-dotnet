namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_To
{
    private string RecipientEmail { get; } = "recipient@domain.com";
    private string RecipientDisplayName { get; } = "Recipient";
    private EmailAddress _recipient1 { get; } = new("recipient1@domain.com", "Recipient 1");
    private EmailAddress _recipient2 { get; } = new("recipient2@domain.com");



    #region To

    [Test]
    public void To_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.To(null!, _recipient1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void To_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.To(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void To_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.To([]);

        act.Should().NotThrow();
    }

    [Test]
    public void To_ShouldAddRecipientsToCollection()
    {
        To_CreateAndValidate(_recipient1, _recipient2);
    }

    [Test]
    public void To_ShouldAddRecipientsToCollection_WhenCalledMultipleTimes()
    {
        var recipient3 = new EmailAddress("recipient3@domain.com");
        var recipient4 = new EmailAddress("recipient4@domain.com", "Recipient 4");

        var request = To_CreateAndValidate(_recipient1, _recipient2);

        request.To(recipient3, recipient4);

        request.To.Should()
            .HaveCount(4).And
            .ContainInOrder(_recipient1, _recipient2, recipient3, recipient4);
    }

    [Test]
    public void To_ShouldNotAddRecipientsToCollection_WhenParamsIsEmpty()
    {
        var request = To_CreateAndValidate(_recipient1, _recipient2);

        request.To([]);

        request.To.Should()
            .HaveCount(2).And
            .ContainInOrder(_recipient1, _recipient2);
    }


    private static SendEmailRequest To_CreateAndValidate(params EmailAddress[] recipients)
    {
        var request = SendEmailRequest
            .Create()
            .To(recipients);

        request.To.Should()
            .HaveCount(2).And
            .ContainInOrder(recipients);

        return request;
    }

    #endregion



    #region To(email, displayName)
    [Test]
    public void To_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.To(null!, RecipientEmail);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void To_ShouldThrowArgumentNullException_WhenRecipientEmailIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.To(null!, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void To_ShouldThrowArgumentNullException_WhenRecipientEmailIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.To(string.Empty, RecipientDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void To_ShouldNotThrowException_WhenRecipientDisplayNameIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.To(RecipientEmail, null);

        act.Should().NotThrow();
    }

    [Test]
    public void To_ShouldNotThrowException_WhenRecipientDisplayNameIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.To(RecipientEmail, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void To_ShouldAddRecipientToCollection_WhenOnlyEmailProvided()
    {
        var request = SendEmailRequest
            .Create()
            .To(RecipientEmail);

        request.To.Should().ContainSingle();

        var added = request.To.First();
        added.Email.Should().Be(RecipientEmail);
        added.DisplayName.Should().BeNull();
    }

    [Test]
    public void To_ShouldAddRecipientToCollection_WhenFullInfoProvided()
    {
        var request = SendEmailRequest
            .Create()
            .To(RecipientEmail, RecipientDisplayName);

        request.To.Should().ContainSingle();

        var added = request.To.First();
        added.Email.Should().Be(RecipientEmail);
        added.DisplayName.Should().Be(RecipientDisplayName);
    }

    #endregion
}
