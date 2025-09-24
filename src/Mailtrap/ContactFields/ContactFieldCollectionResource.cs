namespace Mailtrap.ContactFields;

/// <summary>
/// Implementation of Contact Field Collection resource.
/// </summary>
internal sealed class ContactFieldCollectionResource : RestResource, IContactFieldCollectionResource
{
    public ContactFieldCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<ContactField>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<ContactField>(cancellationToken).ConfigureAwait(false);

    public async Task<ContactField> Create(CreateContactFieldRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateContactFieldRequest, ContactField>(request, cancellationToken).ConfigureAwait(false);
}
