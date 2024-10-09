// -----------------------------------------------------------------------
// <copyright file="EmailMessageHtmlBody.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents HTML body details of a message.
/// </summary>
public sealed record EmailMessageHtmlBody
{
    /// <summary>
    /// Gets HTML body of the message (if exists).
    /// </summary>
    ///
    /// <value>
    /// HTML body of the message (if exists).
    /// </value>
    public string? HtmlBody { get; }
}
