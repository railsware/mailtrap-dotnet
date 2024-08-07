// -----------------------------------------------------------------------
// <copyright file="OperationResultResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Responses;


/// <summary>
/// Generic Mailtrap API response object containing operation result and optional error data.
/// </summary>
public record OperationResultResponse<TError>
{
    /// <summary>
    /// Value indicating whether contains a success response data.
    /// </summary>
    [JsonPropertyName("success")]
    [JsonPropertyOrder(1)]
    public bool IsSuccess { get; }

    /// <summary>
    /// Error(s) associated with the response.
    /// </summary>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(2)]
    public TError? ErrorData { get; }



    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResultResponse{TError}"/> class.
    /// </summary>
    /// 
    /// <param name="isSuccess">
    /// A flag indicating whether the response describes success or failure.
    /// </param>
    /// 
    /// <param name="errorData">
    /// Errors to associate with the response.
    /// </param>
    public OperationResultResponse(bool isSuccess, TError? errorData = default)
    {
        IsSuccess = isSuccess;
        ErrorData = errorData;
    }
}
