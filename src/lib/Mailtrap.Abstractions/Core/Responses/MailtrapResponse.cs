// -----------------------------------------------------------------------
// <copyright file="MailtrapResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Responses;


/// <summary>
/// Generic Mailtrap API response object.
/// </summary>
public record MailtrapResponse<TError>
{
    /// <summary>
    /// Gets a flag, indicating whether request succeeded or failed and response contains error(s).
    /// </summary>
    ///
    /// <value>
    /// <see langword="false"/> when request failed and response contains error(s).<br/>
    /// <see langword="true"/> when request succeeded.
    /// </value>
    [JsonPropertyName("success")]
    [JsonPropertyOrder(1)]
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets error(s) object, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// <typeparamref name="TError"/> instance, containing error(s) details.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(2)]
    public TError? ErrorData { get; }



    /// <summary>
    /// Initializes a new instance of the <see cref="MailtrapResponse{TError}"/> class.
    /// </summary>
    /// 
    /// <param name="isSuccess">
    /// Flag, indicating whether request succeeded or failed and response contains error(s).
    /// </param>
    /// 
    /// <param name="errorData">
    /// Error(s) to associate with the response.
    /// </param>
    public MailtrapResponse(bool isSuccess, TError? errorData = default)
    {
        IsSuccess = isSuccess;
        ErrorData = errorData;
    }
}
