// -----------------------------------------------------------------------
// <copyright file="EmailMessageTextBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents text body details of a message.
/// </summary>
public sealed record EmailMessageTextBody
{
    /// <summary>
    /// Gets or sets plain text body of the message (if exists).
    /// </summary>
    ///
    /// <value>
    /// Plain text body of the message (if exists).
    /// </value>
    public string? TextBody { get; }
}
