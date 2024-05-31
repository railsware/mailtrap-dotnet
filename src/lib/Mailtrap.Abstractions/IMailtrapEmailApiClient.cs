// -----------------------------------------------------------------------
// <copyright file="IMailtrapEmailApiClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Main Mailtrap Email API client entry point.
/// </summary>
public interface IMailtrapEmailApiClient
{
    /// <summary>
    /// Sends provided <paramref name="request"/> to an API endpoint and returns result.<br/>
    /// Request is checked for validity before send. Validation exception is thrown if validation fails.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="EmailSendApiResponse"/> instance with response data.</returns>
    /// <example>
    ///     <code>
    ///          var client = new MailtrapEmailApiClient("https://send.api.mailtrap.io/", "api-token");
    ///          var request = EmailSendApiRequestBuilder
    ///             .Create()
    ///             .WithSender("john.doe@demomailtrap.com", "John Doe")
    ///             .WithSubject("Invitation to Earth")
    ///             .WithRecipient("bill.hero@galactic.com")
    ///             .WithTextBody("Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");
    ///          var result = await client.SendAsync(request);
    ///     </code>
    /// </example>
    Task<EmailSendApiResponse?> SendAsync(EmailSendApiRequest request, CancellationToken cancellationToken = default);
}
