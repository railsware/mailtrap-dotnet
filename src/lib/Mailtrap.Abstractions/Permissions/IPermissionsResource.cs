// -----------------------------------------------------------------------
// <copyright file="IPermissionsResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Permissions;


/// <summary>
/// Represents account permissions resource.
/// </summary>
public interface IPermissionsResource
{
    /// <summary>
    /// Get all resources in your account (Inboxes, Projects, Domains, Billing and Account itself)
    /// to which the API token has admin access.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing a collection of resources with their permission levels.
    /// </returns>
    public Task<CollectionResponse<ResourcePermissions>> GetResources(CancellationToken cancellationToken = default);
}
