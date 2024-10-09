// -----------------------------------------------------------------------
// <copyright file="UpdateEmailMessageRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


// TODO: add validation

/// <summary>
/// Request object for updating message.
/// </summary>
public sealed record UpdateEmailMessageRequest
{
    /// <summary>
    /// Gets or sets message details.
    /// </summary>
    ///
    /// <value>
    /// Message details.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public UpdateEmailMessageRequestDetails? Message { get; set; }
}
