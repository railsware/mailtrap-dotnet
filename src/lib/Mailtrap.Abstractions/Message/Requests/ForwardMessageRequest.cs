// -----------------------------------------------------------------------
// <copyright file="ForwardMessageRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Requests;


// TODO: add validation

/// <summary>
/// Request object for forwarding a message.
/// </summary>
public sealed record ForwardMessageRequest
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
