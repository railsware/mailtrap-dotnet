namespace Mailtrap.ContactLists;

/// <summary>
/// Represents Contacts List resource.
/// </summary>
public interface IContactsListResource : IRestResource
{
    /// <summary>
    /// Gets details of the contacts list, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested contacts list details.
    /// </returns>
    public Task<ContactsList> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the contacts list, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Contacts list details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated contacts list details.
    /// </returns>
    public Task<ContactsList> Update(ContactsListRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a contacts list, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Nothing is returned upon successful deletion.
    /// </returns>
    ///
    /// <remarks>
    /// <para>
    /// After deletion of the contacts list, represented by the current resource instance, it will be no longer available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task Delete(CancellationToken cancellationToken = default);
}
