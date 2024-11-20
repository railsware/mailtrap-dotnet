// -----------------------------------------------------------------------
// <copyright file="EmailMessageHtmlSource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents HTML source details of a message.
/// </summary>
public sealed record EmailMessageHtmlSource
{
    /// <summary>
    /// Gets HTML source of the message.
    /// </summary>
    ///
    /// <value>
    /// HTML source of the message.
    /// </value>
    public string? HtmlSource { get; set; }
}
