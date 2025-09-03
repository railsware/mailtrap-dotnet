using Mailtrap.Contacts.Responses;

namespace Mailtrap.Contacts;

/// <summary>
/// Implementation of Contacts API operations.
/// </summary>
internal sealed class ContactResource : RestResource, IContactResource
{
    public ContactResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }
    public async Task<ContactResponse> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactResponse>(cancellationToken).ConfigureAwait(false);
    public async Task<UpdateContactResponse> Update(UpdateContactRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateContactRequestDto, UpdateContactResponse>(request.ToDto(), cancellationToken).ConfigureAwait(false);
    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);
}
