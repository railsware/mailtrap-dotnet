namespace Mailtrap.Emails;


/// <summary>
/// <see cref="IEmailClientEndpointProvider"/> implementation.
/// </summary>
internal sealed class EmailClientEndpointProvider : IEmailClientEndpointProvider
{
    private const string SendEmailSegment = "send";
    private const string BatchEmailSegment = "batch";


    public Uri GetRequestUri(bool isBatch, bool isBulk, long? inboxId)
    {
        var rootUrl = inboxId switch
        {
            null => isBulk ? Endpoints.BulkDefaultUrl : Endpoints.SendDefaultUrl,
            _ => Endpoints.TestDefaultUrl,
        };

        var emailSegment = isBatch ? BatchEmailSegment : SendEmailSegment;

        var result = rootUrl.Append(UrlSegments.ApiRootSegment, emailSegment);

        return inboxId is null ? result : result.Append(inboxId.Value);
    }
}
