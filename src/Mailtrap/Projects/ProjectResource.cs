// -----------------------------------------------------------------------
// <copyright file="ProjectResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects;


internal sealed class ProjectResource : RestResource, IProjectResource
{
    public ProjectResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<Project> GetDetails(CancellationToken cancellationToken = default)
        => await Get<Project>(cancellationToken).ConfigureAwait(false);

    public async Task<Project> Update(UpdateProjectRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateProjectRequestDto, Project>(request.ToDto(), cancellationToken).ConfigureAwait(false);

    public async Task<DeleteProjectResponse> Delete(CancellationToken cancellationToken = default)
        => await Delete<DeleteProjectResponse>(cancellationToken).ConfigureAwait(false);
}
