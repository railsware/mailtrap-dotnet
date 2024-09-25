// -----------------------------------------------------------------------
// <copyright file="CreateSendingDomainRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomain.Requests;


// TODO: Add validation

/// <summary>
/// Request object for creating sending domain.
/// </summary>
public sealed record CreateSendingDomainRequest
{
    /// <summary>
    /// Gets or sets sending domain request payload.
    /// </summary>
    ///
    /// <value>
    /// Sending domain request payload.
    /// </value>
    [JsonPropertyName("sending_domain")]
    [JsonPropertyOrder(1)]
    public CreateSendingDomainRequestDetails? Domain { get; set; }
}
