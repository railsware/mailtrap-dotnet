namespace Mailtrap.ContactEvents;

/// <summary>
/// Implementation of Contacts Event Collection resource.
/// </summary>
internal sealed class ContactsEventCollectionResource : RestResource, IContactsEventCollectionResource
{
    public ContactsEventCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactsEvent> Create(CreateContactsEventRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateContactsEventRequest, ContactsEvent>(request, cancellationToken).ConfigureAwait(false);
}
