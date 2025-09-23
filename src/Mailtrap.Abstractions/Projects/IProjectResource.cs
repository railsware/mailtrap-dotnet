namespace Mailtrap.Projects;


/// <summary>
/// Represents project resource.
/// </summary>
public interface IProjectResource : IRestResource
{
    /// <summary>
    /// Gets details and inboxes of the project, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Requested project details.
    /// </returns>
    public Task<Project> GetDetails(CancellationToken cancellationToken = default);


    /// <summary>
    /// Updates the project, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Project details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Updated project details.
    /// </returns>
    public Task<Project> Update(UpdateProjectRequest request, CancellationToken cancellationToken = default);


    /// <summary>
    /// Deletes a project, represented by the current resource instance, with all its inboxes.
    /// </summary>
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// <returns>
    /// Deleted project details.
    /// </returns>
    /// <remarks>
    /// <para>
    /// All inboxes, associated with the project, will be deleted as well.
    /// </para>
    /// <para>
    /// After deletion of the project, represented by the current resource instance, it will be no longer available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task<DeleteProjectResponse> Delete(CancellationToken cancellationToken = default);
}
