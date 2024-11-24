// -----------------------------------------------------------------------
// <copyright file="GetAllSendingDomainResponseDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Response object for fetching all sending domains.
/// </summary>
internal sealed record GetAllSendingDomainResponseDto
{
    /// <summary>
    /// Gets a collection of sending domains.
    /// </summary>
    ///
    /// <value>
    /// Collection of sending domains.
    /// </value>
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<SendingDomain> Domains { get; } = [];
}
