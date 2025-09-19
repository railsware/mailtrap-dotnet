using Mailtrap.Contacts.Responses;

namespace Mailtrap.Contacts;

/// <summary>
/// Implementation of Contact Collection resource.
/// </summary>
internal sealed class ContactCollectionResource : RestResource, IContactCollectionResource
{
    private const string ImportsSegment = "imports";

    public ContactCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public IContactsImportCollectionResource Imports()
        => new ContactsImportCollectionResource(RestResourceCommandFactory, ResourceUri.Append(ImportsSegment));

    public IContactsImportResource Import(long importId)
            => new ContactsImportResource(RestResourceCommandFactory, ResourceUri.Append(ImportsSegment).Append(importId));

    public async Task<IList<Contact>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<Contact>(cancellationToken).ConfigureAwait(false);

    public async Task<CreateContactResponse> Create(CreateContactRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateContactRequestDto, CreateContactResponse>(request.ToDto(), cancellationToken).ConfigureAwait(false);
}
