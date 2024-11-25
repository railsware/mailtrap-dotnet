// -----------------------------------------------------------------------
// <copyright file="EmailAttachmentFilter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Attachments.Models;


/// <summary>
/// Represents a set of filtering parameters for the message attachment fetching.
/// </summary>
public sealed record EmailAttachmentFilter
{
    /// <summary>
    /// Gets or sets a disposition type of attachments that will be returned by fetch.<br />
    /// If specified, only attachments with particular <see cref="DispositionType"/> are returned.
    /// </summary>
    ///
    /// <value>
    /// Disposition type of attachments that will be returned by fetch.
    /// </value>
    public DispositionType? Disposition { get; set; }
}
