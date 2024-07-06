// -----------------------------------------------------------------------
// <copyright file="MailtrapClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <inheritdoc cref="IMailtrapClientFactory"/>
public class MailtrapClientFactory : IMailtrapClientFactory
{
    private readonly ServiceProvider _serviceProvider;


    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClientFactory"/> 
    /// with provided <paramref name="configuration"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="configure"></param>
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
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="httpClient"></param>
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> or <paramref name="httpClient"/> is <see langword="null"/>.
    /// </exception>
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
    /// using provided <paramref name="apiKey"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="configure"></param>
    public MailtrapClientFactory(
        string apiKey,
        Action<IHttpClientBuilder>? configure = default)
        : this(new MailtrapClientOptions(apiKey), configure)
    { }

    /// <summary>
    /// Shortcut constructor to create a new instance of <see cref="MailtrapClientFactory"/>
    /// using provided <paramref name="apiKey"/>
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="httpClient"></param>
    public MailtrapClientFactory(
        string apiKey,
        HttpClient httpClient)
        : this(new MailtrapClientOptions(apiKey), httpClient)
    { }


    /// <inheritdoc/>
    public IMailtrapClient CreateClient()
    {
        return _serviceProvider.GetRequiredService<IMailtrapClient>();
    }



    #region IDisposable

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes <see cref="IServiceProvider"/> instance,
    /// that is used to create <see cref="IMailtrapClient"/> instances.
    /// </summary>
    protected virtual void Dispose(bool _)
    {
        _serviceProvider.Dispose();
    }

    #endregion
}
