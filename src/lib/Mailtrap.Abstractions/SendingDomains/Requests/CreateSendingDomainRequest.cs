// -----------------------------------------------------------------------
// <copyright file="CreateSendingDomainRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request object for creating sending domain.
/// </summary>
public sealed record CreateSendingDomainRequest
{
    /// <summary>
    /// Gets sending domain name.
    /// </summary>
    ///
    /// <value>
    /// Sending domain name.
    /// </value>
    [JsonPropertyName("domain_name")]
    [JsonPropertyOrder(1)]
    public string DomainName { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="domainName">
    /// Name for the domain to create.
    /// </param>
    public CreateSendingDomainRequest(string domainName)
    {
        Ensure.NotNullOrEmpty(domainName, nameof(domainName));

        DomainName = domainName;
    }
}
