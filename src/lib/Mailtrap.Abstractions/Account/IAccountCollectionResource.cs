// -----------------------------------------------------------------------
// <copyright file="IAccountCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Account;


/// <summary>
/// Represents account collection resource.
/// </summary>
public interface IAccountCollectionResource
{
    /// <summary>
    /// Gets details of all accounts to which the API token has access.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing a collection of accounts details.
    /// </returns>
    public Task<CollectionResponse<AccountDetails>> GetAll(CancellationToken cancellationToken = default);
}
