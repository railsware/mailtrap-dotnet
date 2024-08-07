// -----------------------------------------------------------------------
// <copyright file="IEmailClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Mailtrap API client for sending emails.
/// </summary>
public interface IEmailClient
{
    /// <summary>
    /// Sends provided <paramref name="request"/> to an API endpoint and returns result.
    /// </summary>
    /// 
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> object with email configuration.
    /// </param>
    /// 
    /// <param name="endpoint">
    /// </param>
    /// 
    /// <param name="inboxId">
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// </param>
    /// 
    /// <returns>
    /// <see cref="SendEmailResponse"/> instance with response data.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="JsonException"/>
    /// <exception cref="TaskCanceledException"/>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="HttpRequestException"/>
    ///
    /// <remarks>
    /// Request is checked for validity before send. Exception is thrown if validation fails.
    /// </remarks>
    Task<SendEmailResponse?> SendEmail(
        SendEmailRequest request,
        Endpoint endpoint = Endpoint.Send,
        int? inboxId = default,
        CancellationToken cancellationToken = default);
}
