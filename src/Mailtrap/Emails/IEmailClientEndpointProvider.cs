namespace Mailtrap.Emails;


/// <summary>
/// Provider to get request URIs for <see cref="EmailClient{TRequest, TResponse}"/>.
/// </summary>
internal interface IEmailClientEndpointProvider
{
    public Uri GetSendRequestUri(bool isBulk, long? inboxId);
    public Uri GetBatchRequestUri(long? inboxId);
}
