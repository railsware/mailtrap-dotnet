// -----------------------------------------------------------------------
// <copyright file="AccountAccessFilter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents a set of filtering parameters for the account access fetching.
/// </summary>
public sealed record AccountAccessFilter
{
    /// <summary>
    /// Gets the list of IDs of the domains for which to include the results.
    /// </summary>
    ///
    /// <value>
    /// List of IDs of the domains for which to include the results.
    /// </value>
    public IList<long> DomainIds { get; } = [];

    /// <summary>
    /// Gets the list of IDs of the inboxes for which to include the results.
    /// </summary>
    ///
    /// <value>
    /// List of IDs of the inboxes for which to include the results.
    /// </value>
    public IList<long> InboxIds { get; } = [];

    /// <summary>
    /// Gets the list of IDs of the projects for which to include the results.
    /// </summary>
    ///
    /// <value>
    /// List of IDs of the projects for which to include the results.
    /// </value>
    public IList<long> ProjectIds { get; } = [];
}
