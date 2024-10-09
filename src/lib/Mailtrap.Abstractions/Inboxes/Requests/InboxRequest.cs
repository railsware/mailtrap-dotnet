// -----------------------------------------------------------------------
// <copyright file="InboxRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


// TODO: add validation

/// <summary>
/// Generic request object for inbox CRUD operations.
/// </summary>
public record InboxRequest<T> where T : InboxRequestDetails
{
    /// <summary>
    /// Gets or sets inbox details.
    /// </summary>
    /// 
    /// <value>
    /// Inbox details.
    /// </value>
    [JsonPropertyName("inbox")]
    [JsonPropertyOrder(1)]
    public T? Inbox { get; set; }
}
