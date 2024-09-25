// -----------------------------------------------------------------------
// <copyright file="DeletedProjectDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Project.Models;


/// <summary>
/// Represents details for deleted project.
/// </summary>
public sealed record DeletedProjectDetails
{
    /// <summary>
    /// Gets the deleted project identifier.
    /// </summary>
    ///
    /// <value>
    /// Deleted project identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    public long? DeletedProjectId { get; }
}
