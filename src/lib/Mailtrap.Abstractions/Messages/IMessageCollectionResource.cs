// -----------------------------------------------------------------------
// <copyright file="IMessageCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Messages;


/// <summary>
/// Represents message collection resource.
/// </summary>
public interface IMessageCollectionResource
{
    /// <summary>
    /// Fetches a collection of messages using provided filtering parameters.
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
    /// Response containing a collection of message details.
    /// </returns>
    ///
    /// <remarks>
    /// The response contains up to 30 messages.<br />
    /// Use <paramref name="filter"/> parameters to retrieve more.
    /// </remarks>
    public Task<CollectionResponse<MessageDetails>> Fetch(
        MessageFilter? filter = default,
        CancellationToken cancellationToken = default);
}
