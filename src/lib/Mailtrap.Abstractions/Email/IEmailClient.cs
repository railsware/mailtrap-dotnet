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
    /// Gets <see cref="Uri"/> representing endpoint URL which is used to send emails for the current instance.
    /// </summary>
    ///
    /// <value>
    /// <see cref="Uri"/> representing endpoint URL to send emails.
    /// </value>
    public Uri SendUri { get; }

    /// <summary>
    /// Sends email, represented by the <paramref name="request"/>, and returns send operation result.
    /// </summary>
    /// 
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> instance, containing email data.
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
    /// When <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    /// When <paramref name="request"/> contains invalid data.
    /// </exception>
    ///
    /// <exception cref="JsonException">
    /// When request serialization or API response deserialization fails for any reason.
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
    /// <exception cref="InvalidResponseFormatException">
    /// When response from the API has an invalid format.
    /// </exception>
    ///
    /// <remarks>
    /// Request is checked for validity before send.<br />
    /// <see cref="ArgumentException"/> is thrown if validation fails.
    /// </remarks>
    public Task<SendEmailResponse> Send(SendEmailRequest request, CancellationToken cancellationToken = default);
}
