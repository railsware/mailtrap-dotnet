// -----------------------------------------------------------------------
// <copyright file="IMailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Mailtrap API client.
/// </summary>
public interface IMailtrapClient : IEmailClient
{
    /// <summary>
    /// Gets account collection resource.
    /// </summary>
    /// 
    /// <returns>
    /// Account collection resource.
    /// </returns>
    public IAccountCollectionResource Accounts();

    /// <summary>
    /// Gets resource for specific account, identified by <paramref name="accountId"/>.
    /// </summary>
    ///
    /// <param name="accountId">
    /// ID of account to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the account with specified ID.
    /// </returns>
    public IAccountResource Account(long accountId);
}
