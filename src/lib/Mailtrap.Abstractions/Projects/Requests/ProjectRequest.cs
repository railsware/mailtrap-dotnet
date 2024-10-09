// -----------------------------------------------------------------------
// <copyright file="ProjectRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


// TODO: Add validation

/// <summary>
/// Generic request object for project CRUD operations.
/// </summary>
public record ProjectRequest<T> where T : ProjectRequestDetails
{
    /// <summary>
    /// Gets or sets project request payload.
    /// </summary>
    ///
    /// <value>
    /// Project request payload.
    /// </value>
    [JsonPropertyName("project")]
    [JsonPropertyOrder(1)]
    public T? Project { get; set; }
}
