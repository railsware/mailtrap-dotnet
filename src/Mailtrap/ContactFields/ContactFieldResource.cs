namespace Mailtrap.ContactFields;

/// <summary>
/// Implementation of Contact Field API operations.
/// </summary>
internal sealed class ContactFieldResource : RestResource, IContactFieldResource
{
    public ContactFieldResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }
    public async Task<ContactField> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactField>(cancellationToken).ConfigureAwait(false);
    public async Task<ContactField> Update(UpdateContactFieldRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateContactFieldRequest, ContactField>(request, cancellationToken).ConfigureAwait(false);
    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);
}
