// -----------------------------------------------------------------------
// <copyright file="UpdateEmailMessageRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


/// <summary>
/// Request object for updating message.
/// </summary>
internal sealed record UpdateEmailMessageRequestDto
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
    public UpdateEmailMessageRequest? Message { get; set; }
}
