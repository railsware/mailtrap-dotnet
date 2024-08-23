// -----------------------------------------------------------------------
// <copyright file="IEmailClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


/// <summary>
/// Mailtrap API client for sending emails.
/// </summary>
public interface IEmailClient
{
    /// <summary>
    /// Sends email, defined by provided <paramref name="request"/> and returns operation result.
    /// </summary>
    /// 
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> instance with email configuration.
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
    /// </exception>
    /// 
    /// <exception cref="ArgumentException">
    /// When <paramref name="request"/> contains invalid data and fails validation.
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
    /// Request is checked for validity before send.<br />
    /// <see cref="ArgumentException"/> is thrown if validation fails.
    /// </remarks>
    Task<SendEmailResponse?> Send(SendEmailRequest request, CancellationToken cancellationToken = default);
}
