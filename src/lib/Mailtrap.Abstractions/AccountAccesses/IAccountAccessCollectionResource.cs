// -----------------------------------------------------------------------
// <copyright file="IAccountAccessCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses;


/// <summary>
/// Represents account access collection resource.
/// </summary>
public interface IAccountAccessCollectionResource
{
    /// <summary>
    /// Gets a collection of account accesses for which specifier_type is User or Invite.    
    /// </summary>
    /// 
    /// <param name="accountAccessFilter">
    /// A set of filtering parameters.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Collection of account accesses with their permissions.
    /// </returns>
    ///
    /// <remarks>
    /// <para>
    /// You must have account admin/owner permissions for this endpoint to work.
    /// </para>
    /// <para>
    /// If you specify Domain IDs, Project IDs or Inbox IDs in <paramref name="accountAccessFilter"/>,
    /// the endpoint will return account accesses for these resources.
    /// </para>
    /// </remarks> 
    public Task<IList<AccountAccess>> Fetch(
        AccountAccessFilter? accountAccessFilter = default,
        CancellationToken cancellationToken = default);
}
