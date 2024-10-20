// -----------------------------------------------------------------------
// <copyright file="UpdateEmailMessageRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


/// <summary>
/// Represents message details for update.
/// </summary>
public sealed record UpdateEmailMessageRequest
{
    /// <summary>
    /// Gets the flag, indicating if message is read.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if message is read.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("is_read")]
    [JsonPropertyOrder(1)]
    public bool IsRead { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="isRead">
    /// Flag, indicating if message is read.
    /// </param>
    public UpdateEmailMessageRequest(bool isRead)
    {
        IsRead = isRead;
    }
}
