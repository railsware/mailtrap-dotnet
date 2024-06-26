// -----------------------------------------------------------------------
// <copyright file="EmailAddress.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// Represents sender's or recipient's email address and name tuple, that can be used in From, To, CC or BCC parameters.
/// </summary>
public record EmailAddress
{
    /// <summary>
    /// Sender's or recipient's email address.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string Email { get; }

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
    /// Primary constructor. Creates a new <see cref="EmailAddress"/> instance with provided parameters.
    /// </summary>
    /// <param name="email">Required.</param>
    /// <param name="displayName">Optional.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public EmailAddress(string email, string? displayName = default)
    {
        Ensure.NotNullOrEmpty(email, nameof(email));

        Email = email;
        DisplayName = displayName;
    }
}
