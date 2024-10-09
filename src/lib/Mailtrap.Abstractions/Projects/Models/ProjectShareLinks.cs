// -----------------------------------------------------------------------
// <copyright file="ProjectShareLinks.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Models;


/// <summary>
/// Represents project share links.
/// </summary>
public sealed record ProjectShareLinks
{
    /// <summary>
    /// Gets a sharing link for admin.
    /// </summary>
    ///
    /// <value>
    /// Sharing link for admin.
    /// </value>
    [JsonPropertyName("admin")]
    [JsonPropertyOrder(1)]
    public string? Admin { get; }

    /// <summary>
    /// Gets a sharing link for viewer.
    /// </summary>
    ///
    /// <value>
    /// Sharing link for viewer.
    /// </value>
    [JsonPropertyName("viewer")]
    [JsonPropertyOrder(2)]
    public string? Viewer { get; }
}
