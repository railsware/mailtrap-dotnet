namespace Mailtrap.ContactLists;

/// <summary>
/// Implementation of Contacts Lists Collection resource.
/// </summary>
internal sealed class ContactsListCollectionResource : RestResource, IContactsListCollectionResource
{
    public ContactsListCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<ContactsList>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<ContactsList>(cancellationToken).ConfigureAwait(false);

    public async Task<ContactsList> Create(ContactsListRequest request, CancellationToken cancellationToken = default)
        => await Create<ContactsListRequest, ContactsList>(request, cancellationToken).ConfigureAwait(false);
}
