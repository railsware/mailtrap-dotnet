// -----------------------------------------------------------------------
// <copyright file="CreateSendingDomainRequestDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomain.Models;


// TODO: Add validation

/// <summary>
/// Represents sending domain details for create operation.
/// </summary>
public sealed record CreateSendingDomainRequestDetails
{
    /// <summary>
    /// Gets or sets sending domain name.
    /// </summary>
    ///
    /// <value>
    /// Sending domain name.
    /// </value>
    [JsonPropertyName("domain_name")]
    [JsonPropertyOrder(1)]
    public string? DomainName { get; set; }
}
