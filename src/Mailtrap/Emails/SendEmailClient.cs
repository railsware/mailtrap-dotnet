namespace Mailtrap.Emails;


/// <summary>
/// <see cref="ISendEmailClient"/> implementation.
/// </summary>
internal sealed class SendEmailClient : EmailClient<SendEmailRequest, SendEmailResponse>, ISendEmailClient
{
    /// <inheritdoc />
    public SendEmailClient(IRestResourceCommandFactory restResourceCommandFactory, Uri sendUri)
        : base(restResourceCommandFactory, sendUri) { }
}
