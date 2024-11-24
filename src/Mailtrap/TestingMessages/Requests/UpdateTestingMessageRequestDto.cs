// -----------------------------------------------------------------------
// <copyright file="UpdateTestingMessageRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Requests;


/// <summary>
/// Request object for updating message.
/// </summary>
internal sealed record UpdateTestingMessageRequestDto
{
    /// <summary>
    /// Gets or sets message details.
    /// </summary>
    ///
    /// <value>
    /// Message details.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public UpdateTestingMessageRequest? Message { get; set; }
}
