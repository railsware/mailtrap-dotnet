// -----------------------------------------------------------------------
// <copyright file="UpdateInboxRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


/// <summary>
/// Request object for inbox update operation.
/// </summary>
public sealed record UpdateInboxRequest : InboxRequest
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

    /// <summary>
    /// Gets or sets email user name for the inbox.
    /// </summary>
    /// 
    /// <value>
    /// Email user name for the inbox.
    /// </value>
    [JsonPropertyName("email_username")]
    [JsonPropertyOrder(2)]
    public string? EmailUsername { get; set; }
}
