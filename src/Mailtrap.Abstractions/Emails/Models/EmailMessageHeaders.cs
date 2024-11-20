// -----------------------------------------------------------------------
// <copyright file="EmailMessageHeaders.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents headers details for the message.
/// </summary>
public sealed record EmailMessageHeaders
{
    /// <summary>
    /// Gets a collection of the message headers.
    /// </summary>
    ///
    /// <value>
    /// Collection of the message headers.
    /// </value>
    [JsonPropertyName("headers")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();
}
