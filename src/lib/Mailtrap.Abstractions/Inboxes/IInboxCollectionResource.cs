// -----------------------------------------------------------------------
// <copyright file="IInboxCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes;


/// <summary>
/// Represents inbox collection resource.
/// </summary>
public interface IInboxCollectionResource
{
    /// <summary>
    /// Gets inbox details collection.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing a collection of inbox details.
    /// </returns>
    public Task<CollectionResponse<Inbox>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new inbox with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing inbox details for creation.
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing created inbox details.
    /// </returns>
    public Task<Response<Inbox>> Create(CreateInboxRequest request, CancellationToken cancellationToken = default);
}
