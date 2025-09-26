namespace Mailtrap.ContactLists;

/// <summary>
/// Represents contact list resource.
/// </summary>
public interface IContactListResource : IRestResource
{
    /// <summary>
    /// Gets details of the contact list, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested contact list details.
    /// </returns>
    public Task<ContactList> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the contact list, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Contact list details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated contact list details.
    /// </returns>
    public Task<ContactList> Update(ContactListRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a contact list, represented by the current resource instance.
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
    /// After deletion of the contact list, represented by the current resource instance, it will no longer be available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task Delete(CancellationToken cancellationToken = default);
}
