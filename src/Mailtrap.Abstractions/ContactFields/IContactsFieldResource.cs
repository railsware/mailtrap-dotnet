namespace Mailtrap.ContactFields;

/// <summary>
/// Represents Contacts Field resource.
/// </summary>
public interface IContactsFieldResource : IRestResource
{
    /// <summary>
    /// Gets details of the contacts field, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested contacts field details.
    /// </returns>
    public Task<ContactsField> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the contacts field, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Contacts field details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated contacts field details.
    /// </returns>
    public Task<ContactsField> Update(UpdateContactsFieldRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a contacts field, represented by the current resource instance.
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
    /// After deletion of the contacts field, represented by the current resource instance, it will no longer be available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task Delete(CancellationToken cancellationToken = default);
}
