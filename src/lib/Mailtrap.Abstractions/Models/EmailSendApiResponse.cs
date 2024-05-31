// -----------------------------------------------------------------------
// <copyright file="EmailSendApiResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Email Send API call response object
/// </summary>
public record EmailSendApiResponse : ApiResponse<IList<string>>
{
    /// <summary>
    /// List of message IDs
    /// </summary>
    [JsonPropertyName("message_ids")]
    public IList<MessageId>? MessageIds { get; }


    public EmailSendApiResponse(bool success, IList<MessageId>? messageIds = null, IList<string>? errorData = null)
        : base(success, errorData ?? [])
    {
        MessageIds = messageIds ?? [];
    }
}
