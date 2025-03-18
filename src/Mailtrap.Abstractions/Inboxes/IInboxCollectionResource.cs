namespace Mailtrap.Inboxes;


/// <summary>
/// Represents inbox collection resource.
/// </summary>
public interface IInboxCollectionResource : IRestResource
{
    /// <summary>
    /// Gets inbox details collection.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Collection of inbox details.
    /// </returns>
    public Task<IList<Inbox>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new inbox with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing inbox details for creation.
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Created inbox details.
    /// </returns>
    public Task<Inbox> Create(CreateInboxRequest request, CancellationToken cancellationToken = default);
}
