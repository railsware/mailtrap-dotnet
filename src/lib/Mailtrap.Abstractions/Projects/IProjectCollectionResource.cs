// -----------------------------------------------------------------------
// <copyright file="IProjectCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects;


/// <summary>
/// Represents project collection resource.
/// </summary>
public interface IProjectCollectionResource
{
    /// <summary>
    /// Gets projects and their inboxes.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing a collection of project details.
    /// </returns>
    public Task<CollectionResponse<ProjectDetails>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new project with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing project details for creation.
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing created project details.
    /// </returns>
    public Task<Response<ProjectDetails>> Create(CreateProjectRequest request, CancellationToken cancellationToken = default);
}
