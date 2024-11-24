// -----------------------------------------------------------------------
// <copyright file="ITestingMessageCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages;


/// <summary>
/// Represents testing message collection resource.
/// </summary>
public interface ITestingMessageCollectionResource : IRestResource
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
    /// Collection of message details.
    /// </returns>
    ///
    /// <remarks>
    /// The response contains up to 30 messages.<br />
    /// Use <paramref name="filter"/> parameters to retrieve more.
    /// </remarks>
    public Task<IList<TestingMessage>> Fetch(
        TestingMessageFilter? filter = default,
        CancellationToken cancellationToken = default);
}
