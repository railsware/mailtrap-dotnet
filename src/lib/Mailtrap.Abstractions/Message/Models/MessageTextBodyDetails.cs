// -----------------------------------------------------------------------
// <copyright file="MessageTextBodyDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents text body details of a message.
/// </summary>
public sealed record MessageTextBodyDetails
{
    /// <summary>
    /// Gets plain text body of the message (if exists).
    /// </summary>
    ///
    /// <value>
    /// Plain text body of the message (if exists).
    /// </value>
    public string? TextBody { get; }
}
