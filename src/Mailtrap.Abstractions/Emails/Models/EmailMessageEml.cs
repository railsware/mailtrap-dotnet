// -----------------------------------------------------------------------
// <copyright file="EmailMessageEml.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents message details in .eml format.
/// </summary>
public sealed record EmailMessageEml
{
    /// <summary>
    /// Gets message in .eml format.
    /// </summary>
    ///
    /// <value>
    /// Message in .eml format.
    /// </value>
    public string? Eml { get; set; }
}
