// -----------------------------------------------------------------------
// <copyright file="EmailSendApiResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Mailtrap API send email call response object
/// </summary>
public record EmailSendApiResponse : ApiResponse<IList<string>>
{
    /// <summary>
    /// List of <see cref="MessageId"/> objects, representing IDs of emails sent
    /// </summary>
    [JsonPropertyName("message_ids")]
    public IList<MessageId>? MessageIds { get; }


    internal EmailSendApiResponse(bool success, IList<MessageId>? messageIds = null, IList<string>? errorData = null)
        : base(success, errorData ?? [])
    {
        MessageIds = messageIds ?? [];
    }
}
