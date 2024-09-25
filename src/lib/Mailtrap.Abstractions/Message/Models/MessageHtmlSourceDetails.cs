// -----------------------------------------------------------------------
// <copyright file="MessageHtmlSourceDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents HTML source details of a message.
/// </summary>
public sealed record MessageHtmlSourceDetails
{
    /// <summary>
    /// Gets HTML source of the message.
    /// </summary>
    ///
    /// <value>
    /// HTML source of the message.
    /// </value>
    public string? HtmlSource { get; }
}
