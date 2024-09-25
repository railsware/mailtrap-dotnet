// -----------------------------------------------------------------------
// <copyright file="SendEmailResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Responses;


/// <summary>
/// Represents send email response object.
/// </summary>
public sealed record SendEmailResponse : OperationResultResponse<IList<string>>
{
    /// <summary>
    /// Gets an empty response object.
    /// </summary>
    ///
    /// <value>
    /// Empty response object.
    /// </value>
    public static SendEmailResponse Empty { get; } = new(false, errorData: ["Empty response."]);


    /// <summary>
    /// Gets a collection of <see cref="MessageId"/> objects, representing IDs of emails that have been sent.
    /// </summary>
    ///
    /// <value>
    /// A collection of <see cref="MessageId"/> objects, representing IDs of emails that have been sent.
    /// </value>
    [JsonPropertyName("message_ids")]
    [JsonPropertyOrder(3)]
    public IList<MessageId> MessageIds { get; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="success">
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
    public SendEmailResponse(bool success, IList<MessageId>? messageIds = default, IList<string>? errorData = default)
        : base(success, errorData ?? [])
    {
        MessageIds = messageIds ?? [];
    }
}
