namespace Mailtrap.Core.Http;


/// <summary>
/// A <see cref="IHttpClientProvider"/> implementation,
/// which returns <see cref="HttpClient"/> instance,
/// obtained from <see cref="IHttpClientFactory"/>.
/// </summary>
internal sealed class FactoryHttpClientProvider : IHttpClientProvider
{
    private readonly IHttpClientFactory _httpClientFactory;


    public HttpClient Client => _httpClientFactory.CreateClient(Constants.Client.Name);


    public FactoryHttpClientProvider(IHttpClientFactory httpClientFactory)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));

        _httpClientFactory = httpClientFactory;
    }
}
