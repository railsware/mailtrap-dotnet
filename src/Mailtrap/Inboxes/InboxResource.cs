namespace Mailtrap.Inboxes;


internal sealed class InboxResource : RestResource, IInboxResource
{
    private const string MessagesSegment = "messages";

    private const string CleanSegment = "clean";
    private const string MarkReadSegment = "all_read";
    private const string ResetCredentialsSegment = "reset_credentials";
    private const string ToggleEmailAddressSegment = "toggle_email_username";
    private const string ResetEmailAddressSegment = "reset_email_username";


    public InboxResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public ITestingMessageCollectionResource Messages()
        => new TestingMessageCollectionResource(RestResourceCommandFactory, ResourceUri.Append(MessagesSegment));

    public ITestingMessageResource Message(long messageId)
        => new TestingMessageResource(RestResourceCommandFactory, ResourceUri.Append(MessagesSegment).Append(messageId));


    public async Task<Inbox> GetDetails(CancellationToken cancellationToken = default)
        => await Get<Inbox>(cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> Update(UpdateInboxRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateInboxRequestDto, Inbox>(request.ToDto(), cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> Delete(CancellationToken cancellationToken = default)
        => await Delete<Inbox>(cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> Clean(CancellationToken cancellationToken = default)
        => await Patch(CleanSegment, cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> MarkAsRead(CancellationToken cancellationToken = default)
        => await Patch(MarkReadSegment, cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> ResetCredentials(CancellationToken cancellationToken = default)
        => await Patch(ResetCredentialsSegment, cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> ToggleEmailAddress(CancellationToken cancellationToken = default)
        => await Patch(ToggleEmailAddressSegment, cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> ResetEmailAddress(CancellationToken cancellationToken = default)
        => await Patch(ResetEmailAddressSegment, cancellationToken).ConfigureAwait(false);


    private async Task<Inbox> Patch(string segment, CancellationToken cancellationToken)
    {
        var uri = ResourceUri.Append(segment);

        var result = await RestResourceCommandFactory
            .CreatePatch<Inbox>(uri)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
