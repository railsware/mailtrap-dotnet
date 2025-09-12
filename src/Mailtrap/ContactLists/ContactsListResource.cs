namespace Mailtrap.ContactLists;

/// <summary>
/// Implementation of Contacts List API operations.
/// </summary>
internal sealed class ContactsListResource : RestResource, IContactsListResource
{
    public ContactsListResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }
    public async Task<ContactsList> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactsList>(cancellationToken).ConfigureAwait(false);
    public async Task<ContactsList> Update(ContactsListRequest request, CancellationToken cancellationToken = default)
        => await Update<ContactsListRequest, ContactsList>(request, cancellationToken).ConfigureAwait(false);
    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);
}
