// -----------------------------------------------------------------------
// <copyright file="IAccountAccessResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses;


/// <summary>
/// Represents account access resource.
/// </summary>
public interface IAccountAccessResource
{
    /// <summary>
    /// Manages user or token permissions for the account access, represented by the current resource instance.
    /// </summary>
    /// 
    /// <param name="request">
    /// Permission details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing operation result details.
    /// </returns>
    ///
    /// <remarks>
    /// This operation performs an upsert.<br />
    /// If you send a combination of resource_type and resource_id that already exists, the permission is updated.<br />
    /// Otherwise, if the combination doesn't exist, the permission is created.
    /// </remarks>
    public Task<Response<UpdatedPermissions>> UpdatePermissions(
        UpdatePermissionsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes account access, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing deleted account access details.
    /// </returns>
    ///
    /// <remarks>
    /// <para>
    /// If specifier type is User, it removes user permissions.<br />
    /// If specifier type is Invite or ApiToken, it removes specifier along with permissions.
    /// </para>
    /// <para>
    /// You have to be an account admin/owner for this endpoint to work.
    /// </para>
    /// <para>
    /// After deletion of the account access, represented by the current resource instance, it will be no longer available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task<Response<DeletedAccountAccess>> Delete(CancellationToken cancellationToken = default);
}
