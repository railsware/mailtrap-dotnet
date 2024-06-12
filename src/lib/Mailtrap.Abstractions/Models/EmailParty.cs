// -----------------------------------------------------------------------
// <copyright file="Recipient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Represents sender's or recipient's email address and name tuple, that can be used in From, To, CC or BCC parameters
/// </summary>
public record EmailParty
{
    [JsonPropertyName("email")]
    public string EmailAddress { get; }

    [JsonPropertyName("name")]
    public string? DisplayName { get; }


    /// <summary>
    /// Primary constructor. Creates a new <see cref="EmailParty"/> instance with provided parameters
    /// </summary>
    /// <param name="emailAddress">Required. </param>
    /// <param name="displayName"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public EmailParty(string emailAddress, string? displayName = null)
    {
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        EmailAddress = emailAddress;
        DisplayName = displayName;
    }
}
