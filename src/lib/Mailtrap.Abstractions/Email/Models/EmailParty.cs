// -----------------------------------------------------------------------
// <copyright file="EmailParty.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// Represents sender's or recipient's email address and name tuple, that can be used in From, To, CC or BCC parameters.
/// </summary>
public record EmailParty
{
    /// <summary>
    /// Sender's or recipient's email address.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string EmailAddress { get; }

    /// <summary>
    /// Sender's or recipient's display name.
    /// </summary>
    /// <remarks>
    /// Optional.
    /// </remarks>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? DisplayName { get; }


    /// <summary>
    /// Primary constructor. Creates a new <see cref="EmailParty"/> instance with provided parameters.
    /// </summary>
    /// <param name="emailAddress">Required.</param>
    /// <param name="displayName">Optional.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public EmailParty(string emailAddress, string? displayName = default)
    {
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        EmailAddress = emailAddress;
        DisplayName = displayName;
    }
}
