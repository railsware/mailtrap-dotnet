namespace Mailtrap.Emails;


/// <summary>
/// <see cref="IEmailClientEndpointProvider"/> implementation.
/// </summary>
internal sealed class EmailClientEndpointProvider : IEmailClientEndpointProvider
{
    private const string SendEmailSegment = "send";


    public Uri GetSendRequestUri(bool isBulk, long? inboxId)
    {
        var rootUrl = inboxId switch
        {
            null => isBulk ? Endpoints.BulkDefaultUrl : Endpoints.SendDefaultUrl,
            _ => Endpoints.TestDefaultUrl,
        };

        var result = rootUrl.Append(UrlSegments.ApiRootSegment, SendEmailSegment);

        return inboxId is null ? result : result.Append(inboxId.Value);
    }
}
