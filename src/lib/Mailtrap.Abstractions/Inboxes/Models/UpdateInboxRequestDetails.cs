// -----------------------------------------------------------------------
// <copyright file="UpdateInboxRequestDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Models;


// TODO: add validation

/// <summary>
/// Represents inbox details for the update.
/// </summary>
public sealed record UpdateInboxRequestDetails : InboxRequestDetails
{
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
