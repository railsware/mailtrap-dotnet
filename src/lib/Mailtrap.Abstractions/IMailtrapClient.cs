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
    /// to an API endpoint and returns operation result.
    /// </summary>
    /// <remarks>
    /// Request is checked for validity before send. <see cref="ArgumentException"/> is thrown if validation fails.
    /// </remarks>
    /// <param name="request"><see cref="SendEmailRequest"/> object with email configuration.</param>
    /// <param name="endpoint"></param>
    /// <param name="inboxId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="SendEmailResponse"/> instance with response data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="JsonException"/>
    /// <exception cref="TaskCanceledException"/>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="HttpRequestException"/>
    Task<SendEmailResponse?> SendAsync(SendEmailRequest request, Endpoint endpoint = Endpoint.Send, int? inboxId = null, CancellationToken cancellationToken = default);
}
