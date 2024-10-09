// -----------------------------------------------------------------------
// <copyright file="ProjectRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


/// <summary>
/// Generic request object for project CRUD operations.
/// </summary>
internal record ProjectRequestDto<T> where T : ProjectRequest
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
