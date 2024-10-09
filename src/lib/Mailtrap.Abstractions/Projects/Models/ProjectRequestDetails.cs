// -----------------------------------------------------------------------
// <copyright file="ProjectRequestDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Models;


// TODO: add validation

/// <summary>
/// Represents basic project details for CRUD operations.
/// </summary>
public record ProjectRequestDetails
{
    /// <summary>
    /// Gets or sets project name.
    /// </summary>
    ///
    /// <value>
    /// Project name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; set; }
}
