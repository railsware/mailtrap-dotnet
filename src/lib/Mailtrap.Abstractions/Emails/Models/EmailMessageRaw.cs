// -----------------------------------------------------------------------
// <copyright file="EmailMessageRaw.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents message details in a raw format.
/// </summary>
public sealed record EmailMessageRaw
{
    /// <summary>
    /// Gets message in a raw format.
    /// </summary>
    ///
    /// <value>
    /// Message in a raw format.
    /// </value>
    public string? Raw { get; }
}
