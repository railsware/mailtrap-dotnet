using Mailtrap.ContactFields.Models;
using Mailtrap.ContactFields.Requests;

namespace Mailtrap.ContactFields;

/// <summary>
/// Implementation of Contacts API operations.
/// </summary>
internal sealed class ContactsFieldResource : RestResource, IContactsFieldResource
{
    public ContactsFieldResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }
    public async Task<ContactsField> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactsField>(cancellationToken).ConfigureAwait(false);
    public async Task<ContactsField> Update(UpdateContactsFieldRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateContactsFieldRequest, ContactsField>(request, cancellationToken).ConfigureAwait(false);
    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);
}
