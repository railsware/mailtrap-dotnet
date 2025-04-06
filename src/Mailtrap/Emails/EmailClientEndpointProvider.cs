namespace Mailtrap.Emails;


/// <summary>
/// <see cref="IEmailClientEndpointProvider"/> implementation.
/// </summary>
internal sealed class EmailClientEndpointProvider : IEmailClientEndpointProvider
{
    private const string SendEmailSegment = "send";
    private const string BatchEmailSegment = "batch";


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

    public Uri GetBatchRequestUri(long? inboxId)
    {
        Ensure.NotNull(inboxId, nameof(inboxId));

        return Endpoints.TestDefaultUrl
            .Append(UrlSegments.ApiRootSegment, BatchEmailSegment)
            .Append(inboxId!.Value);
    }
}
