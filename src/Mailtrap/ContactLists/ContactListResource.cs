namespace Mailtrap.ContactLists;

/// <summary>
/// Implementation of Contact List API operations.
/// </summary>
internal sealed class ContactListResource : RestResource, IContactListResource
{
    public ContactListResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }
    public async Task<ContactList> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactList>(cancellationToken).ConfigureAwait(false);
    public async Task<ContactList> Update(ContactListRequest request, CancellationToken cancellationToken = default)
        => await Update<ContactListRequest, ContactList>(request, cancellationToken).ConfigureAwait(false);
    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);
}
