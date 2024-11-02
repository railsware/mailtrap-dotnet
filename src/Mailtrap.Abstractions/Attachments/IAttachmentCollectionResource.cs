// -----------------------------------------------------------------------
// <copyright file="IAttachmentCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Attachments;


/// <summary>
/// Represents message attachment collection resource.
/// </summary>
public interface IAttachmentCollectionResource : IRestResource
{
    /// <summary>
    /// Fetches a collection of message attachments considering provided filtering parameters.
    /// </summary>
    ///
    /// <param name="filter">
    /// A set of filtering parameters.
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Collection of message attachments.
    /// </returns>
    public Task<IList<EmailAttachment>> Fetch(
        EmailAttachmentFilter? filter = default,
        CancellationToken cancellationToken = default);
}
