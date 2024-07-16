
namespace Mailtrap.Core.Responses;


/// <summary>
/// Generic Mailtrap API response object containing operation result and optional error data.
/// </summary>
public record OperationResultResponse<TError>
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
    public bool Success { get; }

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
    /// Initializes a new instance of the <see cref="OperationResultResponse{TError}"/> class.
    /// </summary>
    /// 
    /// <param name="success">
    /// Flag, indicating whether request succeeded or failed and response contains error(s).
    /// </param>
    /// 
    /// <param name="errorData">
    /// Error(s) to associate with the response.
    /// </param>
    public OperationResultResponse(bool success, TError? errorData = default)
    {
        Success = success;
        ErrorData = errorData;
    }
}
