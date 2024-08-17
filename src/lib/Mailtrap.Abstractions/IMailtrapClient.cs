// -----------------------------------------------------------------------
// <copyright file="IMailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Mailtrap API client.
/// </summary>
public interface IMailtrapClient
{
    /// <summary>
    /// Gets instance of the <see cref="ISendClient"/> for transactional send.
    /// </summary>
    /// 
    /// <returns>
    /// Instance of the <see cref="ISendClient"/> for transactional send.
    /// </returns>
    public ISendClient Transactional();

    /// <summary>
    /// Gets instance of the <see cref="ISendClient"/> for bulk send.
    /// </summary>
    /// 
    /// <returns>
    /// Instance of the <see cref="ISendClient"/> for bulk send.
    /// </returns>
    public ISendClient Bulk();

    /// <summary>
    /// Gets instance of the <see cref="ISendClient"/> for test send.
    /// </summary>
    /// 
    /// <returns>
    /// Instance of the <see cref="ISendClient"/> for test send.
    /// </returns>
    public ISendClient Test(long inboxId);
}
