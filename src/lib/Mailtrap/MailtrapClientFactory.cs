// -----------------------------------------------------------------------
// <copyright file="MailtrapClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Default <see cref="IMailtrapClientFactory"/> implementation.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Uses <see cref="IHttpClientFactory"/> under the hood to create <see cref="HttpClient"/> instances
/// and inject them into the <see cref="IMailtrapClient"/> default implementation instances
/// produced by the factory. Thus, it is recommended to use it as singleton.
/// </para>
///
/// <para>
/// <see cref="IMailtrapClient"/> default implementation instances produced by the factory can be used in any manner,
/// since they are designed to use unit-of-work pattern under the hood, ensuring proper disposal of resources,
/// as soon as any operation is completed. However, considering that default
/// <see cref="IMailtrapClient"/> implementation it isn't thread safe,
/// singleton usage is not recommended, especially in multi-threaded environments.
/// </para>
/// </remarks>

public class MailtrapClientFactory : IMailtrapClientFactory
{
    private readonly ServiceProvider _serviceProvider;


    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClientFactory"/> 
    /// with provided <paramref name="configuration"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// 
    /// <param name="configuration">
    /// <see cref="MailtrapClientOptions"/> instance to configure factory.
    /// </param>
    /// 
    /// <param name="configure">
    /// Optional delegate to configure underlying <see cref="HttpClient"/>.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClientFactory(
        MailtrapClientOptions configuration,
        Action<IHttpClientBuilder>? configure = default)
    {
        Ensure.NotNull(configuration, nameof(configuration));

        var serviceCollection = new ServiceCollection();

        var httpClientBuilder = serviceCollection.AddMailtrapClient(configuration);

        configure?.Invoke(httpClientBuilder);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClientFactory"/> 
    /// using provided <paramref name="configuration"/>
    /// and preconfigured external <see cref="HttpClient"/> instance.
    /// </summary>
    /// 
    /// <param name="configuration">
    /// <see cref="MailtrapClientOptions"/> instance to configure factory.
    /// </param>
    /// 
    /// <param name="httpClient">
    /// External <see cref="HttpClient"/> instance to use within factory.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> or <paramref name="httpClient"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Factory won't dispose captured <paramref name="httpClient"/> instance upon disposal,
    /// so it is responsibility of the caller to manage its lifecycle properly.
    /// </remarks>
    public MailtrapClientFactory(MailtrapClientOptions configuration, HttpClient httpClient)
    {
        Ensure.NotNull(configuration, nameof(configuration));
        Ensure.NotNull(httpClient, nameof(httpClient));

        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure<MailtrapClientOptions>(options => options.Init(configuration));

        serviceCollection.AddMailtrapServices<StaticHttpClientLifetimeAdapterFactory>();

        serviceCollection.AddSingleton(httpClient);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    /// <summary>
    /// Shortcut constructor to create a new instance of <see cref="MailtrapClientFactory"/> 
    /// using provided <paramref name="apiToken"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// <para>
    /// All other configuration settings will be set to default values.
    /// </para>
    /// </summary>
    /// 
    /// <param name="apiToken">
    /// API authentication token.
    /// </param>
    /// 
    /// <param name="configure">
    /// Optional delegate to configure underlying <see cref="HttpClient"/>.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="apiToken"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClientFactory(
        string apiToken,
        Action<IHttpClientBuilder>? configure = default)
        : this(new MailtrapClientOptions(apiToken), configure)
    { }

    /// <summary>
    /// Shortcut constructor to create a new instance of <see cref="MailtrapClientFactory"/>
    /// using provided <paramref name="apiToken"/>
    /// and preconfigured external <see cref="HttpClient"/> instance.
    /// <para>
    /// All other configuration settings will be set to default values.
    /// </para>
    /// </summary>
    /// 
    /// <param name="apiToken">
    /// API authentication token.
    /// </param>
    /// 
    /// <param name="httpClient">
    /// External <see cref="HttpClient"/> instance to use within factory.
    /// <para>
    /// Factory won't dispose captured <paramref name="httpClient"/> instance upon disposal,
    /// so it is responsibility of the caller to manage its lifecycle properly.
    /// </para>
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="apiToken"/> or <paramref name="httpClient"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClientFactory(
        string apiToken,
        HttpClient httpClient)
        : this(new MailtrapClientOptions(apiToken), httpClient)
    { }


    /// <inheritdoc/>
    public IMailtrapClient CreateClient() => _serviceProvider.GetRequiredService<IMailtrapClient>();



    #region IDisposable

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes internal <see cref="IServiceProvider"/> instance,
    /// that is used to spawn <see cref="IMailtrapClient"/> implementation instances.
    /// </summary>
    /// 
    /// <param name="disposing">
    /// Flag to indicate the flow from which the call is performed.
    /// <para>
    /// <see langword="true"/> indicates a call from the <see cref="Dispose()"/> method.<br/>
    /// <see langword="false"/> indicates a call from finalizer.
    /// </para>
    /// </param>
    protected virtual void Dispose(bool disposing) => _serviceProvider.Dispose();

    #endregion
}
