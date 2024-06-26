// -----------------------------------------------------------------------
// <copyright file="IMailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Main Mailtrap API client entry point.
/// </summary>
public interface IMailtrapClient
{
    /// <summary>
    /// Sends provided <paramref name="request"/> to an API endpoint and returns result.
    /// </summary>
    /// <remarks>
    /// Request is checked for validity before send. Exception is thrown if validation fails.
    /// </remarks>
    /// <param name="request"><see cref="SendEmailRequest"/> object with email configuration.</param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="SendEmailResponse"/> instance with response data.</returns>
    /// <example>
    ///     <code>
    ///          var client = new MailtrapEmailApiClient(&quot;https://send.api.mailtrap.io/&quot;, &quot;api-token&quot;);
    ///          var request = EmailSendApiRequestBuilder
    ///             .Create&lt;RegularEmailSendApiRequest&gt;()
    ///             .WithSender(&quot;john.doe@demomailtrap.com&quot;, &quot;John Doe&quot;)
    ///             .WithSubject(&quot;Invitation to Earth&quot;)
    ///             .WithRecipient(&quot;bill.hero@galactic.com&quot;)
    ///             .WithTextBody(&quot;Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.&quot;);
    ///          var result = await client.SendAsync(request);
    ///     </code>
    /// </example>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="JsonException"/>
    /// <exception cref="TaskCanceledException"/>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="HttpRequestException"/>
    Task<SendEmailResponse?> SendAsync(SendEmailRequest request, CancellationToken cancellationToken = default);
}
