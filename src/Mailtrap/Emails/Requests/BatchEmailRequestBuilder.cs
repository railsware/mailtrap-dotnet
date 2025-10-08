namespace Mailtrap.Emails.Requests;


/// <summary>
/// A set of helper methods to streamline <see cref="BatchEmailRequest"/> instance construction using fluent style.
/// </summary>
public static class BatchEmailRequestBuilder
{
    #region Requests

    /// <summary>
    /// Adds provided <paramref name="requests"/> to the <see cref="BatchEmailRequest.Requests"/>
    /// collection of the <paramref name="batchRequest"/>.
    /// </summary>
    ///
    /// <param name="batchRequest">
    /// <see cref="BatchEmailRequest"/> instance to update.
    /// </param>
    ///
    /// <param name="requests">
    /// One or more <see cref="SendEmailRequest"/> objects to add to the batch request's requests collection.
    /// </param>
    ///
    /// <returns>
    /// Updated <see cref="BatchEmailRequest"/> instance so subsequent calls can be chained.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// When <paramref name="batchRequest"/> or <paramref name="requests"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Duplicates can be added by calling this method multiple times with the same requests.
    /// </remarks>
    public static BatchEmailRequest Requests(this BatchEmailRequest batchRequest, params SendEmailRequest[] requests)
    {
        Ensure.NotNull(batchRequest, nameof(batchRequest));
        Ensure.NotNull(batchRequest.Requests, nameof(batchRequest.Requests));
        Ensure.NotNull(requests, nameof(requests));

        batchRequest.Requests.AddRange(requests);

        return batchRequest;
    }

    /// <summary>
    /// Adds provided <paramref name="requests"/> to the <see cref="BatchEmailRequest.Requests"/>
    /// collection of the <paramref name="batchRequest"/>.
    /// </summary>
    ///
    /// <param name="batchRequest">
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/param[@name='batchRequest']"/>
    /// </param>
    ///
    /// <param name="requests">
    /// Collection of <see cref="SendEmailRequest"/> objects to add to the batch request's requests collection.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/returns"/>
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/exception[@id='ArgumentNullException']"/>
    /// </exception>
    ///
    /// <remarks>
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/remarks"/>
    /// </remarks>
    public static BatchEmailRequest Requests(this BatchEmailRequest batchRequest, IEnumerable<SendEmailRequest> requests)
    {
        Ensure.NotNull(batchRequest, nameof(batchRequest));
        Ensure.NotNull(batchRequest.Requests, nameof(batchRequest.Requests));
        Ensure.NotNull(requests, nameof(requests));

        batchRequest.Requests.AddRange(requests);

        return batchRequest;
    }

    /// <summary>
    /// Adds provided <paramref name="request"/> to the <see cref="BatchEmailRequest.Requests"/>
    /// collection of the <paramref name="batchRequest"/>.
    /// </summary>
    ///
    /// <param name="batchRequest">
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/param[@name='batchRequest']"/>
    /// </param>
    ///
    /// <param name="request">
    /// Single <see cref="SendEmailRequest"/> object to add to the batch request's requests collection.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/returns"/>
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// When <paramref name="batchRequest"/> or <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <remarks>
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/remarks"/>
    /// </remarks>
    public static BatchEmailRequest Requests(this BatchEmailRequest batchRequest, SendEmailRequest request)
    {
        Ensure.NotNull(batchRequest, nameof(batchRequest));
        Ensure.NotNull(batchRequest.Requests, nameof(batchRequest.Requests));
        Ensure.NotNull(request, nameof(request));

        batchRequest.Requests.Add(request);

        return batchRequest;
    }

    #endregion

    #region Base

    /// <summary>
    /// Sets provided <paramref name="request"/> to the <paramref name="batchRequest"/>.
    /// </summary>
    ///
    /// <param name="batchRequest">
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/param[@name='batchRequest']"/>
    /// </param>
    ///
    /// <param name="request">
    /// <see cref="EmailAddress"/> object to initialize request's <see cref="BatchEmailRequest.Base"/> property.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/returns"/>
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/exception[@id='ArgumentNullException']"/>
    /// </exception>
    ///
    /// <remarks>
    /// <inheritdoc cref="Requests(BatchEmailRequest, SendEmailRequest[])" path="/remarks"/>
    /// </remarks>
    public static BatchEmailRequest Base(this BatchEmailRequest batchRequest, EmailRequest request)
    {
        Ensure.NotNull(batchRequest, nameof(batchRequest));
        Ensure.NotNull(batchRequest.Requests, nameof(batchRequest.Requests));
        Ensure.NotNull(request, nameof(request));

        batchRequest.Base = request;

        return batchRequest;
    }

    #endregion
}
