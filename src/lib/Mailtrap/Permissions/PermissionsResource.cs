// -----------------------------------------------------------------------
// <copyright file="PermissionsResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Permissions;


internal sealed class PermissionsResource : RestResource, IPermissionsResource
{
    private const string ResourcesSegment = "resources";


    public PermissionsResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<ResourcePermissions>> GetResources(CancellationToken cancellationToken = default)
        => await GetList<ResourcePermissions>(ResourceUri.Append(ResourcesSegment), cancellationToken).ConfigureAwait(false);
}
