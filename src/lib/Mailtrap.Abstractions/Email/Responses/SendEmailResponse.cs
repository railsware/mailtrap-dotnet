// -----------------------------------------------------------------------
// <copyright file="SendEmailResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Responses;


/// <summary>
/// Represents send email response object.
/// </summary>
public record SendEmailResponse : MailtrapResponse<IList<string>>
{
    /// <summary>
    /// Gets a collection of <see cref="MessageId"/> objects, representing IDs of emails that have been sent.
    /// </summary>
    ///
    /// <value>
    /// A collection of <see cref="MessageId"/> objects, representing IDs of emails that have been sent.
    /// </value>
    [JsonPropertyName("message_ids")]
    [JsonPropertyOrder(3)]
    public IList<MessageId>? MessageIds { get; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="isSuccess">
    /// Flag, indicating whether request succeeded or failed and response contains error(s).
    /// </param>
    /// 
    /// <param name="messageIds">
    /// A collection of <see cref="MessageId"/> objects.
    /// </param>
    /// 
    /// <param name="errorData">
    /// Errors to associate with the response.
    /// </param>
    public SendEmailResponse(bool isSuccess, IList<MessageId>? messageIds = default, IList<string>? errorData = default)
        : base(isSuccess, errorData ?? [])
    {
        MessageIds = messageIds ?? [];
    }
}
