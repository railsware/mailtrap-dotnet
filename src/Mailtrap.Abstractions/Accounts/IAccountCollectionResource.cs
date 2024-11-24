// -----------------------------------------------------------------------
// <copyright file="IAccountCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Accounts;


/// <summary>
/// Represents account collection resource.
/// </summary>
public interface IAccountCollectionResource : IRestResource
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
    /// Collection of accounts details.
    /// </returns>
    public Task<IList<Account>> GetAll(CancellationToken cancellationToken = default);
}
