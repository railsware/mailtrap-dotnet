// -----------------------------------------------------------------------
// <copyright file="InvalidResponseFormatException.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Exceptions;


/// <summary>
/// Exception which is thrown when response received from the Mailtrap API has an invalid format.
/// </summary>
public class InvalidResponseFormatException : MailtrapException
{
    private const string DefaultMessageFormat = "Response received from the '{0}' API call has an invalid format.";


    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidResponseFormatException"/> class with default error message.
    /// </summary>
    public InvalidResponseFormatException() : base(FormatExceptionMessage("Mailtrap")) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidResponseFormatException"/> class with a specified error message.
    /// </summary>
    /// 
    /// <param name="message">
    /// <inheritdoc cref="MailtrapException(string)" path="/param[@name='message']"/>
    /// </param>
    public InvalidResponseFormatException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidResponseFormatException"/> class
    /// with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    ///
    /// <param name="message">
    /// <inheritdoc cref="MailtrapException(string, Exception)" path="/param[@name='message']"/>
    /// </param>
    ///
    /// <param name="innerException">
    /// <inheritdoc cref="MailtrapException(string, Exception)" path="/param[@name='innerException']"/>
    /// </param>
    public InvalidResponseFormatException(string message, Exception innerException) : base(message, innerException) { }


    /// <summary>
    /// Creates a new instance of the <see cref="InvalidResponseFormatException"/> class with message
    /// that contains failed API details, defined by <paramref name="apiEndpoint"/>.
    /// </summary>
    ///
    /// <param name="apiEndpoint">
    /// API endpoint identifier that can help uniquely identify the failed API call.
    /// </param>
    ///
    /// <returns>
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When the <paramref name="apiEndpoint"/> is <see langword="null"/> or empty.
    /// </exception>
    public static InvalidResponseFormatException Create(string apiEndpoint)
    {
        Ensure.NotNullOrEmpty(apiEndpoint, nameof(apiEndpoint));

        return new InvalidResponseFormatException(FormatExceptionMessage(apiEndpoint));
    }


    private static string FormatExceptionMessage(string apiEndpoint)
        => string.Format(CultureInfo.InvariantCulture, DefaultMessageFormat, apiEndpoint);
}
