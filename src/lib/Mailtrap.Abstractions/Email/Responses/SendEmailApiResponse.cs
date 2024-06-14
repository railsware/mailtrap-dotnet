// -----------------------------------------------------------------------
// <copyright file="SendEmailApiResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Responses;


/// <summary>
/// Mailtrap API send email call response object
/// </summary>
public record SendEmailApiResponse : ApiResponse<IList<string>>
{
    /// <summary>
    /// List of <see cref="MessageId"/> objects, representing IDs of emails sent
    /// </summary>
    [JsonPropertyName("message_ids")]
    [JsonPropertyOrder(3)]
    public IList<MessageId>? MessageIds { get; }


    public SendEmailApiResponse(bool isSuccess, IList<MessageId>? messageIds = null, IList<string>? errorData = null)
        : base(isSuccess, errorData ?? [])
    {
        MessageIds = messageIds ?? [];
    }
}
