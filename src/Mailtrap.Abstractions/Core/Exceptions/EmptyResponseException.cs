namespace Mailtrap.Core.Exceptions;


/// <summary>
/// Exception which is thrown when response received from the Mailtrap API has no content.
/// </summary>
public sealed class EmptyResponseException : MailtrapApiException
{
    private const string DefaultMessage = "Response received from the API call has no content.";


    /// <inheritdoc />
    public EmptyResponseException(Uri resourceUri, HttpMethod httpMethod)
        : base(resourceUri, httpMethod, DefaultMessage) { }
}
