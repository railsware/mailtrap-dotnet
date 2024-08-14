// -----------------------------------------------------------------------
// <copyright file="IEmailClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


/// <summary>
/// Mailtrap API client for emails.
/// </summary>
public interface IEmailClient
{
    /// <summary>
    /// Sends email, defined by provided <paramref name="request"/>,
    /// to the specified API <paramref name="endpoint"/> and optional <paramref name="inboxId"/>
    /// and returns operation result.
    /// </summary>
    /// 
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> instance with email configuration.
    /// </param>
    ///
    /// <param name="endpoint">
    /// <para>
    /// <see cref="SendEndpoint"/> to send email to.
    /// </para>
    /// <para>
    /// Default is transactional send.<br />
    /// Ignored, if <paramref name="inboxId"/> specified.
    /// </para>
    /// </param>
    ///
    /// <param name="inboxId">
    /// Optional inbox identifier.
    /// <para>
    /// When specified, email will be routed to the test endpoint.
    /// </para>
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// <see cref="SendEmailResponse"/> instance with response data.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br/>
    /// When <paramref name="endpoint"/> is <see cref="SendEndpoint.Test"/>, but <paramref name="inboxId"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref="ArgumentException">
    /// When <paramref name="request"/> contains invalid data and fails validation.    /// 
    /// </exception>
    /// 
    /// <exception cref="JsonException">
    /// When <paramref name="request"/> serialization or response deserialization fails.
    /// </exception>
    /// 
    /// <exception cref="TaskCanceledException">
    /// When operation is canceled by <paramref name="cancellationToken"/>.
    /// </exception>
    /// 
    /// <exception cref="OperationCanceledException">
    /// When operation is canceled by <paramref name="cancellationToken"/>.
    /// </exception>
    /// 
    /// <exception cref="HttpRequestException">
    /// When request to the API fails for any reason.
    /// </exception>
    ///
    /// <remarks>
    /// <para>
    /// Request is checked for validity before send.<br />
    /// <see cref="ArgumentException"/> is thrown if validation fails.
    /// </para>
    /// <para>
    /// By default email is sent to the transactional endpoint.
    /// </para>
    /// <para>
    /// Parameter <paramref name="inboxId"/> is required when <paramref name="endpoint"/> is set to <see cref="SendEndpoint.Test"/>.
    /// </para>
    /// <para>
    /// Parameter <paramref name="endpoint"/> is ignored, in case <paramref name="inboxId"/> is specified.<br />
    /// Email will be always routed to the test endpoint in this case.
    /// </para>
    /// </remarks>
    Task<SendEmailResponse?> SendEmail(
        SendEmailRequest request,
        SendEndpoint? endpoint = default,
        int? inboxId = default,
        CancellationToken cancellationToken = default);
}
