namespace Mailtrap.ContactFields;

/// <summary>
/// Represents Contact Field resource.
/// </summary>
public interface IContactFieldResource : IRestResource
{
    /// <summary>
    /// Gets details of the contact field, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested contact field details.
    /// </returns>
    public Task<ContactField> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the contact field, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Contact field details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated contact field details.
    /// </returns>
    public Task<ContactField> Update(UpdateContactFieldRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a contact field, represented by the current resource instance.
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
    /// After deletion of the contact field, represented by the current resource instance, it will no longer be available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task Delete(CancellationToken cancellationToken = default);
}
