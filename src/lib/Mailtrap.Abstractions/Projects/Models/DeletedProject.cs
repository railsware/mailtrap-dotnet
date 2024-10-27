// -----------------------------------------------------------------------
// <copyright file="DeletedProject.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Models;


/// <summary>
/// Represents details for deleted project.
/// </summary>
public sealed record DeletedProject
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
    [JsonRequired]
    public long Id { get; set; }
}
