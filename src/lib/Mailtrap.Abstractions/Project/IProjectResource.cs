// -----------------------------------------------------------------------
// <copyright file="IProjectResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Project;


/// <summary>
/// Represents project resource.
/// </summary>
public interface IProjectResource
{
    /// <summary>
    /// Gets details and inboxes of the project, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing requested project details.
    /// </returns>
    public Task<Response<ProjectDetails>> GetDetails(CancellationToken cancellationToken = default);


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
    /// Response containing updated project details.
    /// </returns>
    public Task<Response<ProjectDetails>> Update(UpdateProjectRequest request, CancellationToken cancellationToken = default);


    /// <summary>
    /// Deletes a project, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing deleted project details.
    /// </returns>
    ///
    /// <remarks>
    /// After deletion of the project, represented by the current resource instance, it will be no longer available.<br />
    /// Thus any further operations on it will result in an error.
    /// </remarks>
    public Task<Response<DeletedProjectDetails>> Delete(CancellationToken cancellationToken = default);
}
