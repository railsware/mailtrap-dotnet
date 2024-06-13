// -----------------------------------------------------------------------
// <copyright file="ApiResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core;


/// <summary>
/// Generic Mailtrap API response object
/// </summary>
public record ApiResponse<TError>
{
    /// <summary>
    /// Value indicating whether contains a success response data.
    /// </summary>
    [JsonPropertyName("success")]
    public bool IsSuccess { get; }

    /// <summary>
    /// Error(s) associated with the response.
    /// </summary>
    [JsonPropertyName("errors")]
    public TError? ErrorData { get; }



    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResponse{TError}"/> class.
    /// </summary>
    /// <param name="success">A flag indicating whether the response describes success or failure.</param>
    /// <param name="errorData">Errors to associate with the response.</param>
    internal ApiResponse(bool success, TError? errorData = default)
    {
        IsSuccess = success;
        ErrorData = errorData;
    }
}
