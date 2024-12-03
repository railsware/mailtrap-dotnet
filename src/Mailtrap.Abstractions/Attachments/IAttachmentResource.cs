// -----------------------------------------------------------------------
// <copyright file="IAttachmentResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Attachments;


/// <summary>
/// Represents message attachment resource.
/// </summary>
public interface IAttachmentResource : IRestResource
{
    /// <summary>
    /// Gets details of the message attachment, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Requested message attachment details.
    /// </returns>
    public Task<EmailAttachment> GetDetails(CancellationToken cancellationToken = default);
}
