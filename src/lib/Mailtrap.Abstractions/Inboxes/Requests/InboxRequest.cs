// -----------------------------------------------------------------------
// <copyright file="InboxRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


// TODO: add validation

/// <summary>
/// Represents basic inbox details for CRUD requests.
/// </summary>
public record InboxRequest
{
    /// <summary>
    /// Gets or sets inbox name.
    /// </summary>
    /// 
    /// <value>
    /// Inbox name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; set; }
}
