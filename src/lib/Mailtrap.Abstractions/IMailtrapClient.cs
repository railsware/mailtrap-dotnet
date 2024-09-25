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
    /// <para>
    /// Gets default email client.
    /// </para>
    /// <para>
    /// Type of the client (transactional, bulk or test) is defined by configuration.
    /// </para>
    /// </summary>
    /// 
    /// <returns>
    /// <see cref="IEmailClient"/> instance that can be used to send emails to the channel specified by configuration.
    /// </returns>
    public IEmailClient Email();

    /// <summary>
    /// Factory method to create transactional email client.
    /// </summary>
    ///
    /// <returns>
    /// New <see cref="IEmailClient"/> instance that can be used to send transactional emails.
    /// </returns>
    public IEmailClient Transactional();

    /// <summary>
    /// Factory method to create bulk email client.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="IEmailClient"/> instance that can be used to send bulk emails.
    /// </returns>
    public IEmailClient Bulk();

    /// <summary>
    /// Factory method to create test email client.
    /// </summary>
    ///
    /// <param name="inboxId">
    /// ID of the inbox to send test emails to.
    /// </param>
    ///
    /// <returns>
    /// New <see cref="IEmailClient"/> instance that can be used to send test emails to the specified <paramref name="inboxId"/>.
    /// </returns>
    public IEmailClient Test(long inboxId);
}
