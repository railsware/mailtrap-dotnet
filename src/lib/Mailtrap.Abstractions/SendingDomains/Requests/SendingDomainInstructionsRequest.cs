// -----------------------------------------------------------------------
// <copyright file="SendingDomainInstructionsRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request object for sending setup instructions for sending domain.
/// </summary>
public sealed record SendingDomainInstructionsRequest : IValidatable
{
    /// <summary>
    /// Gets email address to send setup instructions to.
    /// </summary>
    ///
    /// <value>
    /// Email address to send setup instructions to.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string Email { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="email">
    /// Email address to send setup instructions to.
    /// </param>
    public SendingDomainInstructionsRequest(string email)
    {
        Ensure.NotNullOrEmpty(email, nameof(email));

        Email = email;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return SendingDomainInstructionsRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
