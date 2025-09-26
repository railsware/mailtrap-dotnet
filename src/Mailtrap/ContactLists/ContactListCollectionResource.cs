namespace Mailtrap.ContactLists;

/// <summary>
/// Implementation of Contact List Collection resource.
/// </summary>
internal sealed class ContactListCollectionResource : RestResource, IContactListCollectionResource
{
    public ContactListCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<ContactList>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<ContactList>(cancellationToken).ConfigureAwait(false);

    public async Task<ContactList> Create(ContactListRequest request, CancellationToken cancellationToken = default)
        => await Create<ContactListRequest, ContactList>(request, cancellationToken).ConfigureAwait(false);
}
