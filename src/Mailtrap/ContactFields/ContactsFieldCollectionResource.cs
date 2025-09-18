using Mailtrap.ContactFields.Models;
using Mailtrap.ContactFields.Requests;

namespace Mailtrap.ContactFields;

/// <summary>
/// Implementation of Contacts Field Collection resource.
/// </summary>
internal sealed class ContactsFieldCollectionResource : RestResource, IContactsFieldCollectionResource
{
    public ContactsFieldCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<ContactsField>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<ContactsField>(cancellationToken).ConfigureAwait(false);

    public async Task<ContactsField> Create(CreateContactsFieldRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateContactsFieldRequest, ContactsField>(request, cancellationToken).ConfigureAwait(false);
}
