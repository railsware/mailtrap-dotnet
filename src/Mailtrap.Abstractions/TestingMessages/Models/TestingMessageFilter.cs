// -----------------------------------------------------------------------
// <copyright file="TestingMessageFilter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Models;


/// <summary>
/// Represents a set of filtering parameters for the message fetching.
/// </summary>
public sealed record TestingMessageFilter
{
    /// <summary>
    /// Gets or sets an ID of the last message that will be returned by fetch.<br />
    /// If specified, a page of records before <see cref="LastId"/> is returned.
    /// </summary>
    ///
    /// <value>
    /// ID of the last message that will be returned by fetch.
    /// </value>
    ///
    /// <remarks>
    /// Overrides <see cref="Page"/> if both are provided.
    /// </remarks>
    public long? LastId { get; set; }

    /// <summary>
    /// Gets or sets a page number for paginated results.
    /// </summary>
    ///
    /// <value>
    /// Page number for paginated results.
    /// </value>
    ///
    /// <remarks>
    /// Is ignored if <see cref="LastId"/> is provided.
    /// </remarks>
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets a query string for search.
    /// </summary>
    ///
    /// <value>
    /// Query string for search.
    /// </value>
    ///
    /// <remarks>
    /// Matches subject, email and name from TO field.
    /// </remarks>
    public string? SearchFilter { get; set; }
}
