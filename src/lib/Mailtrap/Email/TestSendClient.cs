// -----------------------------------------------------------------------
// <copyright file="TestSendClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


/// <summary>
/// <see cref="ISendClient"/> implementation for test send.
/// </summary>
internal sealed class TestSendClient : SendClient
{
    private readonly long _inboxId;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="httpClientFactory"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// <param name="sendEndpointOptions"></param>
    /// <param name="serializationOptions"></param>
    /// <param name="inboxId"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public TestSendClient(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory,
        MailtrapClientEndpointOptions sendEndpointOptions,
        MailtrapClientSerializationOptions serializationOptions,
        long inboxId)
        : base(httpClientFactory, httpRequestMessageFactory, httpRequestContentFactory, sendEndpointOptions, serializationOptions)
    {
        _inboxId = inboxId;
    }


    protected override Uri GetUrlForSend()
    {
        var result = base.GetUrlForSend().Append(_inboxId.ToString(CultureInfo.InvariantCulture));

        return result;
    }
}
