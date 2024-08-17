// -----------------------------------------------------------------------
// <copyright file="SendClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


internal sealed class SendClientFactory : ISendClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly MailtrapClientOptions _clientOptions;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="httpClientFactory"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// <param name="clientOptions"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public SendClientFactory(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory,
        IOptions<MailtrapClientOptions> clientOptions)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));
        Ensure.NotNull(clientOptions, nameof(clientOptions));

        _httpClientFactory = httpClientFactory;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;
        _clientOptions = clientOptions.Value;
    }


    public ISendClient CreateTransactionalClient() => CreateSendClient(_clientOptions.SendEndpoint);

    public ISendClient CreateBulkClient() => CreateSendClient(_clientOptions.BulkEndpoint);

    public ISendClient CreateTestClient(long inboxId) => new TestSendClient(
        _httpClientFactory,
        _httpRequestMessageFactory,
        _httpRequestContentFactory,
        _clientOptions.TestEndpoint,
        _clientOptions.Serialization,
        inboxId);


    private SendClient CreateSendClient(MailtrapClientEndpointOptions sendEndpointOptions) => new(
        _httpClientFactory,
        _httpRequestMessageFactory,
        _httpRequestContentFactory,
        sendEndpointOptions,
        _clientOptions.Serialization);
}
