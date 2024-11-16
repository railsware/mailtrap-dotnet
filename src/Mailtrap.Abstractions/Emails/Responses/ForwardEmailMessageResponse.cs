// -----------------------------------------------------------------------
// <copyright file="ForwardEmailMessageResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Responses;


/// <summary>
/// Details of the forwarded message.
/// </summary>
public sealed record ForwardEmailMessageResponse
{
    /// <summary>
    /// Gets forward result message.
    /// </summary>
    ///
    /// <value>
    /// Forward result message.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public string? Message { get; set; }
}
