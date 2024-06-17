// -----------------------------------------------------------------------
// <copyright file="SendEmailApiResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Responses;


/// <summary>
/// Mailtrap API send email call response object.
/// </summary>
public record SendEmailApiResponse : ApiResponse<IList<string>>
{
    /// <summary>
    /// List of <see cref="MessageId"/> objects, representing IDs of emails sent
    /// </summary>
    [JsonPropertyName("message_ids")]
    [JsonPropertyOrder(3)]
    public IList<MessageId>? MessageIds { get; }


    /// <summary>
    /// Primary constructor with required parameters.
    /// </summary>
    /// <param name="isSuccess">A flag indicating whether the response describes success or failure.</param>
    /// <param name="messageIds">A collection of <see cref="MessageId"/> objects</param>
    /// <param name="errorData">Errors to associate with the response.</param>
    public SendEmailApiResponse(bool isSuccess, IList<MessageId>? messageIds = default, IList<string>? errorData = default)
        : base(isSuccess, errorData ?? [])
    {
        MessageIds = messageIds ?? [];
    }
}
