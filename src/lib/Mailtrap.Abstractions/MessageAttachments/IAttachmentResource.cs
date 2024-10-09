// -----------------------------------------------------------------------
// <copyright file="IAttachmentResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.MessageAttachments;


/// <summary>
/// Represents message attachment resource.
/// </summary>
public interface IAttachmentResource
{
    /// <summary>
    /// Gets details of the message attachment, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing requested message attachment details.
    /// </returns>
    public Task<Response<MessageAttachment>> GetDetails(CancellationToken cancellationToken = default);
}
