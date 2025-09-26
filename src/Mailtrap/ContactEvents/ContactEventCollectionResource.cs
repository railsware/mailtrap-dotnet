namespace Mailtrap.ContactEvents;

/// <summary>
/// Implementation of Contact Event Collection resource.
/// </summary>
internal sealed class ContactEventCollectionResource : RestResource, IContactEventCollectionResource
{
    public ContactEventCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactEvent> Create(CreateContactEventRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateContactEventRequest, ContactEvent>(request, cancellationToken).ConfigureAwait(false);
}
