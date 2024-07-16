// -----------------------------------------------------------------------
// <copyright file="IMailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Mailtrap API Client.
/// </summary>
public interface IMailtrapClient
{
    /// <summary>
    /// Sends email, defined by provided <paramref name="request"/>,
    /// to the provided API <paramref name="endpoint"/> and optional <paramref name="inboxId"/>
    /// and returns operation result.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Request is checked for validity before send. <see cref="ArgumentException"/> is thrown if validation fails.
    /// </para>
    /// <para>
    /// Parameter <paramref name="endpoint"/> will be ignored, in case <paramref name="inboxId"/> is specified.<br />
    /// Email will be always routed to the test endpoint in this case.
    /// </para>
    /// </remarks>
    /// <param name="request"><see cref="SendEmailRequest"/> instance with email configuration.</param>
    /// <param name="endpoint">
    /// <see cref="Endpoint"/> to send email to.<br />
    /// Default is transactional send.<br />
    /// Ignored, if <paramref name="inboxId"/> specified.
    /// </param>
    /// <param name="inboxId">
    /// Optional inbox identifier.<br />
    /// If specified, email will be routed to the test endpoint.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="SendEmailResponse"/> instance with response data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="JsonException"/>
    /// <exception cref="TaskCanceledException"/>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="HttpRequestException"/>
    Task<SendEmailResponse?> SendAsync(
        SendEmailRequest request,
        Endpoint endpoint = Endpoint.Send,
        int? inboxId = default,
        CancellationToken cancellationToken = default);
}
