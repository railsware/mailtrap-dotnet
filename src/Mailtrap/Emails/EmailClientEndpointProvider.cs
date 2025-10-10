namespace Mailtrap.Emails;


/// <summary>
/// <see cref="IEmailClientEndpointProvider"/> implementation.
/// </summary>
internal sealed class EmailClientEndpointProvider : IEmailClientEndpointProvider
{
    private const string SendEmailSegment = "send";
    private const string BatchEmailSegment = "batch";


    /// <summary>
    /// Initializes a new instance of the <see cref="EmailClientEndpointProvider"/> class.
    /// </summary>
    /// <param name="isBatch">if <c>true</c> the batch segment will be used; otherwise, the regular send segment will be used.</param>
    /// <param name="isBulk">if <c>true</c> the bulk email endpoint will be used;
    /// if <c>true</c> and <paramref name="inboxId"/> is provided, the test email endpoint will be used;
    /// otherwise, the single email endpoint will be used.</param>
    /// <param name="inboxId">If inbox identifier provided, the request will be scoped to that inbox.</param>
    /// <returns></returns>
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
