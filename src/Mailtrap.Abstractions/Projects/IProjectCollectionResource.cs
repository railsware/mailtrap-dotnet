// -----------------------------------------------------------------------
// <copyright file="IProjectCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects;


/// <summary>
/// Represents project collection resource.
/// </summary>
public interface IProjectCollectionResource : IRestResource
{
    /// <summary>
    /// Gets projects and their inboxes.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Collection of project details.
    /// </returns>
    public Task<IList<Project>> GetAll(CancellationToken cancellationToken = default);

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
    /// Created project details.
    /// </returns>
    public Task<Project> Create(CreateProjectRequest request, CancellationToken cancellationToken = default);
}
