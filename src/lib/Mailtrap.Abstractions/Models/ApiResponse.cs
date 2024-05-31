// -----------------------------------------------------------------------
// <copyright file="ApiResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Generic API response.
/// </summary>
public record ApiResponse<TError>
{
    /// <summary>
    /// A value indicating whether the response was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; }

    /// <summary>
    /// Errors associated with the response.
    /// </summary>
    [JsonPropertyName("errors")]
    public TError? ErrorData { get; }



    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResponse"/> class.
    /// </summary>
    /// <param name="success">A flag indicating whether the response describes success or failure.</param>
    /// <param name="errorData">Errors to associate with the response.</param>
    public ApiResponse(bool success, TError? errorData)
    {
        Success = success;
        ErrorData = errorData;
    }
}
