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
    /// </summary>
    /// 
    /// <returns>
    /// </returns>
    public IEmailClient Email();

    /// <summary>
    /// </summary>
    ///
    /// <returns>
    /// </returns>
    public IEmailClient Transactional();

    /// <summary>
    /// </summary>
    /// 
    /// <returns>
    /// </returns>
    public IEmailClient Bulk();

    /// <summary>
    /// </summary>
    ///
    /// <param name="inboxId">
    /// </param>
    ///
    /// <returns>
    /// </returns>
    public IEmailClient Test(long inboxId);
}
