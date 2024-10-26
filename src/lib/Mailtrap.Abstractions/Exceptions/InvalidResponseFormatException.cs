// -----------------------------------------------------------------------
// <copyright file="InvalidResponseFormatException.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Exceptions;


/// <summary>
/// Exception which is thrown when response received from the Mailtrap API has an invalid format.
/// </summary>
public sealed class InvalidResponseFormatException : MailtrapException
{
    private const string DefaultMessage = "Response received from the API call has an invalid format.";


    /// <summary>
    /// Gets API endpoint that returned response in invalid format.
    /// </summary>
    ///
    /// <value>
    /// API endpoint that returned response in invalid format.
    /// </value>
    public Uri ApiEndpoint { get; }

    /// <summary>
    /// Gets HTTP method that returned response in invalid format.
    /// </summary>
    ///
    /// <value>
    /// HTTP method that returned response in invalid format.
    /// </value>
    public HttpMethod HttpMethod { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidResponseFormatException"/> with message
    /// that contains failed API details, defined by <paramref name="httpRequest"/>.
    /// </summary>
    ///
    /// <param name="httpRequest">
    /// HTTP request that was used to make the API call.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When the <paramref name="httpRequest"/> is <see langword="null"/>.
    /// </exception>
    public InvalidResponseFormatException(HttpRequestMessage httpRequest) : base(DefaultMessage)
    {
        Ensure.NotNull(httpRequest, nameof(httpRequest));

        ApiEndpoint = httpRequest.RequestUri;
        HttpMethod = httpRequest.Method;
    }
}
