namespace Mailtrap.ContactEvents;

/// <summary>
/// Represents contact event collection resource.
/// </summary>
public interface IContactEventCollectionResource : IRestResource
{
    /// <summary>
    /// Creates a new contact event with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contact event details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Created contact event details.
    /// </returns>
    public Task<ContactEvent> Create(CreateContactEventRequest request, CancellationToken cancellationToken = default);
}
