namespace Mailtrap.ContactEvents;

/// <summary>
/// Represents contacts event collection resource.
/// </summary>
public interface IContactsEventCollectionResource : IRestResource
{
    /// <summary>
    /// Creates a new contacts event with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contacts event details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Created contacts event details.
    /// </returns>
    public Task<ContactsEvent> Create(CreateContactsEventRequest request, CancellationToken cancellationToken = default);
}
