namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_From
{
    private string SenderEmail { get; } = "sender@domain.com";
    private string SenderDisplayName { get; } = "Sender";
    private EmailAddress _sender { get; } = new("sender@domain.com", "Sender");


    #region From(sender)

    [Test]
    public void From_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.From(null!, _sender);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void From_ShouldThrowArgumentNullException_WhenSenderIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.From(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void From_ShouldAssignSenderProperly()
    {
        var request = SendEmailRequest
            .Create()
            .From(_sender);

        request.From.Should().BeSameAs(_sender);
    }

    [Test]
    public void From_ShouldOverrideSender_WhenCalledSeveralTimes()
    {
        var otherSender = new EmailAddress("sender2@domain.com", "Sender 2");

        var request = SendEmailRequest
            .Create()
            .From(_sender)
            .From(otherSender);

        request.From.Should().BeSameAs(otherSender);
    }

    #endregion


    #region From(email, displayName)

    [Test]
    public void From_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.From(null!, SenderEmail);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void From_ShouldThrowArgumentNullException_WhenSenderEmailIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.From(null!, SenderDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void From_ShouldThrowArgumentNullException_WhenSenderEmailIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.From(string.Empty, SenderDisplayName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void From_ShouldNotThrowException_WhenSenderDisplayNameIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.From(SenderEmail, null);

        act.Should().NotThrow();
    }

    [Test]
    public void From_ShouldNotThrowException_WhenSenderDisplayNameIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => request.From(SenderEmail, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void From_ShouldInitializeSenderProperly_WhenOnlyEmailProvided()
    {
        var request = SendEmailRequest
            .Create()
            .From(SenderEmail);

        request.From.Should().NotBeNull();
        request.From!.Email.Should().Be(SenderEmail);
        request.From!.DisplayName.Should().BeNull();
    }

    [Test]
    public void From_ShouldInitializeSenderProperly_WhenFullInfoProvided()
    {
        var request = SendEmailRequest
            .Create()
            .From(SenderEmail, SenderDisplayName);

        request.From.Should().NotBeNull();
        request.From!.Email.Should().Be(SenderEmail);
        request.From!.DisplayName.Should().Be(SenderDisplayName);
    }

    [Test]
    public void From_ShouldOverrideSender_WhenCalledSeveralTimes_2()
    {
        var otherSenderEmail = "sender2@domain.com";

        var request = SendEmailRequest
            .Create()
            .From(_sender)
            .From(otherSenderEmail);

        request.From.Should().NotBeSameAs(_sender);
        request.From!.Email.Should().Be(otherSenderEmail);
        request.From!.DisplayName.Should().BeNull();
    }

    #endregion
}
