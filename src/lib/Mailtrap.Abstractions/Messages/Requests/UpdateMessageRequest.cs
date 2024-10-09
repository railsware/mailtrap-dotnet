// -----------------------------------------------------------------------
// <copyright file="UpdateMessageRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Messages.Requests;


// TODO: add validation

/// <summary>
/// Request object for updating message.
/// </summary>
public sealed record UpdateMessageRequest
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
    public UpdateMessageRequestDetails? Message { get; set; }
}
