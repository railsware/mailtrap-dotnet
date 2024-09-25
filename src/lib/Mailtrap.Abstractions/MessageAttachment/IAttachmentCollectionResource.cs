// -----------------------------------------------------------------------
// <copyright file="IAttachmentCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.MessageAttachment;


/// <summary>
/// Represents message attachment collection resource.
/// </summary>
public interface IAttachmentCollectionResource
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
    /// Response containing a collection of message attachments.
    /// </returns>
    public Task<CollectionResponse<AttachmentDetails>> Fetch(
        AttachmentFilter? filter = default,
        CancellationToken cancellationToken = default);
}
