// -----------------------------------------------------------------------
// <copyright file="ForwardTestingMessageRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Requests;


/// <summary>
/// Request object for forwarding a message.
/// </summary>
public sealed record ForwardTestingMessageRequest : IValidatable
{
    /// <summary>
    /// Gets email to forward to.
    /// </summary>
    ///
    /// <value>
    /// Email to forward to.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string Email { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="email">
    /// Email address to forward email message to.
    /// </param>
    public ForwardTestingMessageRequest(string email)
    {
        Ensure.NotNullOrEmpty(email, nameof(email));

        Email = email;
    }


    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return ForwardTestingMessageRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
