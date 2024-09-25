// -----------------------------------------------------------------------
// <copyright file="MessageHtmlBodyDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents HTML body details of a message.
/// </summary>
public sealed record MessageHtmlBodyDetails
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
