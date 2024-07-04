// -----------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Net.Http.Headers;

namespace Mailtrap.Tests.Extensions.DependencyInjection;


[TestFixture]
internal sealed class ServiceCollectionExtensionsTests
{
    private string _apiToken { get; } = "token";
    private string _baseUrl { get; } = "https://send.api.mailtrap.io/v2/";
    private Uri _baseUri { get; } = new("https://send.api.mailtrap.io/v2/");


    [Test]
    public void AddMailtrapClient_Configuration_ShouldThrowArgumentNullException_WhenServicesIsNull()
    {
        var act = () => ServiceCollectionExtensions.AddMailtrapClient(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddMailtrapClient_Configuration_ShouldConfigureOptions_WhenConfigurationProvided()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            ["Mailtrap:Authentication:ApiToken"] = _apiToken,
            ["Mailtrap:SendEndpoint:BaseUrl"] = _baseUrl
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(configuration.GetSection("Mailtrap"));

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IConfigureOptions<MailtrapClientOptions>) &&
            s.Lifetime == ServiceLifetime.Singleton &&
            s.ImplementationInstance != null);

        var services = serviceCollection.BuildServiceProvider();

        var options = services.GetRequiredService<IOptions<MailtrapClientOptions>>();

        options.Should().NotBeNull();
        options.Value.Should().NotBeNull();
        options.Value.Authentication.ApiToken.Should().Be(_apiToken);
        options.Value.SendEndpoint.BaseUrl.Should().Be(_baseUrl);
    }

    [Test]
    public void AddMailtrapClient_Configuration_ShouldAddDefaultHttpClient_WhenConfigureActionIsNotProvided()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            ["Mailtrap:Authentication:ApiToken"] = _apiToken,
            ["Mailtrap:SendEndpoint:BaseUrl"] = _baseUrl
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(configuration.GetSection("Mailtrap"));

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpClientFactory) &&
            s.Lifetime == ServiceLifetime.Singleton &&
            s.ImplementationFactory != null);

        var services = serviceCollection.BuildServiceProvider();

        using var client = services.GetRequiredService<HttpClient>();

        client.Should().NotBeNull();
    }

    [Test]
    public void AddMailtrapClient_Configuration_ShouldConfigureDefaultHttpClient_WhenConfigureActionIsProvided()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            ["Mailtrap:Authentication:ApiToken"] = _apiToken,
            ["Mailtrap:SendEndpoint:BaseUrl"] = _baseUrl
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(configuration.GetSection("Mailtrap"), builder =>
        {
            builder.ConfigureHttpClient(client =>
            {
                client.BaseAddress = _baseUri;
            });
        });

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpClientFactory) &&
            s.Lifetime == ServiceLifetime.Singleton &&
            s.ImplementationFactory != null);

        var services = serviceCollection.BuildServiceProvider();

        using var client = services.GetRequiredService<HttpClient>();

        client.Should().NotBeNull();

        client.BaseAddress.Should().Be(_baseUri);
    }



    [Test]
    public void AddMailtrapClient_Delegate_ShouldThrowArgumentNullException_WhenServicesIsNull()
    {
        var act = () => ServiceCollectionExtensions.AddMailtrapClient(null!, options => { });

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddMailtrapClient_Delegate_ShouldConfigureOptions_WhenConfigurationProvided()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(options =>
        {
            options.Authentication.ApiToken = _apiToken;
            options.SendEndpoint.BaseUrl = _baseUri;
        });

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IConfigureOptions<MailtrapClientOptions>) &&
            s.Lifetime == ServiceLifetime.Singleton &&
            s.ImplementationInstance != null);

        var services = serviceCollection.BuildServiceProvider();

        var options = services.GetRequiredService<IOptions<MailtrapClientOptions>>();

        options.Should().NotBeNull();
        options.Value.Should().NotBeNull();
        options.Value.Authentication.ApiToken.Should().Be(_apiToken);
        options.Value.SendEndpoint.BaseUrl.Should().Be(_baseUri);
    }

    [Test]
    public void AddMailtrapClient_Delegate_ShouldAddDefaultHttpClient_WhenConfigureActionIsNotProvided()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(
            options =>
            {
                options.Authentication.ApiToken = _apiToken;
                options.SendEndpoint.BaseUrl = _baseUri;
            });

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpClientFactory) &&
            s.Lifetime == ServiceLifetime.Singleton &&
            s.ImplementationFactory != null);

        var services = serviceCollection.BuildServiceProvider();

        using var client = services.GetRequiredService<HttpClient>();

        client.Should().NotBeNull();
    }

    [Test]
    public void AddMailtrapClient_Delegate_ShouldConfigureDefaultHttpClient_WhenConfigureActionIsProvided()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(
            options =>
            {
                options.Authentication.ApiToken = _apiToken;
                options.SendEndpoint.BaseUrl = _baseUri;
            },
            builder =>
            {
                builder.ConfigureHttpClient(httpClient =>
                {
                    httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true
                    };
                });
            });

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpClientFactory) &&
            s.Lifetime == ServiceLifetime.Singleton &&
            s.ImplementationFactory != null);

        var services = serviceCollection.BuildServiceProvider();

        using var client = services.GetRequiredService<HttpClient>();

        client.Should().NotBeNull();

        client.DefaultRequestHeaders.Should().ContainKey("Cache-Control");
        client.DefaultRequestHeaders.CacheControl.Should().NotBeNull();
        client.DefaultRequestHeaders.CacheControl!.NoCache.Should().BeTrue();
    }


    [Test]
    public void AddMailtrapServices_ShouldThrowArgumentNullException_WhenServicesIsNull()
    {
        var act = () => ServiceCollectionExtensions.AddMailtrapServices<StaticHttpClientLifetimeAdapterFactory>(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [TestCase(TypeArgs = [typeof(TransientHttpClientLifetimeAdapterFactory)])]
    [TestCase(TypeArgs = [typeof(StaticHttpClientLifetimeAdapterFactory)])]
    public void AddMailtrapServices_ShouldAddRequiredServices<T>()
        where T : class, IHttpClientLifetimeAdapterFactory
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapServices<T>();

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IOptions<>) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IMailtrapClientConfigurationProvider) &&
            s.ImplementationType == typeof(MailtrapClientConfigurationProvider) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IAccessTokenProvider) &&
            s.ImplementationType == typeof(AccessTokenProvider) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpRequestMessageAuthenticationProvider) &&
            s.ImplementationType == typeof(ApiKeyHttpRequestMessageAuthenticationProvider) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpRequestContentFactory) &&
            s.ImplementationType == typeof(HttpRequestContentFactory) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpRequestMessageFactory) &&
            s.ImplementationType == typeof(HttpRequestMessageFactory) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpRequestMessageConfigurationPolicy) &&
            s.ImplementationType == typeof(HttpRequestMessageConfigurationPolicy) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IHttpClientLifetimeAdapterFactory) &&
            s.ImplementationType == typeof(T) &&
            s.Lifetime == ServiceLifetime.Singleton);

        serviceCollection.Should().Contain(s =>
            s.ServiceType == typeof(IMailtrapClient) &&
            s.ImplementationType == typeof(MailtrapClient) &&
            s.Lifetime == ServiceLifetime.Transient);
    }
}
