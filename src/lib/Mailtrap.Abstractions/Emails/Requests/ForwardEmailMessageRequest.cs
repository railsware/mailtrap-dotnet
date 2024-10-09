// -----------------------------------------------------------------------
// <copyright file="ForwardEmailMessageRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


// TODO: add validation

/// <summary>
/// Request object for forwarding a message.
/// </summary>
public sealed record ForwardEmailMessageRequest
{
    /// <summary>
    /// Gets or sets email to forward to.
    /// </summary>
    ///
    /// <value>
    /// Email to forward to.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string? Email { get; set; }
}
