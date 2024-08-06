---
uid: configure
---


# Mailtrap API Client Configuration
This article covers different configuration options for Mailtrap API client.

> [!CAUTION]  
> Examples below could contain API token specified as a plain text in code or configuration files.  
> This is not a recommended approach and is used only for brevity.
>
> In production scenarios it is highly recommended to use more secure approaches to store sensitive configuration, such as:
> - [Environment variables](https://learn.microsoft.com/aspnet/core/security/app-secrets#environment-variables)
> - [Secrets Manager](https://learn.microsoft.com/aspnet/core/security/app-secrets#secret-manager)
> - [Azure Key Vault](https://learn.microsoft.com/aspnet/core/security/key-vault-configuration)
> - etc.



## Configuration model
Regardless of the configuration approach used for Mailtrap API client setup, which can be found in this article, all of them are using unified configuration model @Mailtrap.Configuration.Models.MailtrapClientOptions under the hood.

Model contains 3 main settings groups:
- [Authentication](xref:Mailtrap.Configuration.Models.MailtrapClientAuthenticationOptions)
- [Serialization](xref:Mailtrap.Configuration.Models.MailtrapClientSerializationOptions)
- And a set of [Endpoint](xref:Mailtrap.Configuration.Models.MailtrapClientEndpointOptions) configurations for different email send channels/API features.

In the common case, the only required configuration setting is @Mailtrap.Configuration.Models.MailtrapClientAuthenticationOptions.ApiToken.  
It is set to empty string by default which will cause configuration validation to fail if left untouched.  

There is a dedicated [constructor](xref:Mailtrap.Configuration.Models.MailtrapClientOptions.%23ctor(System.String)), that takes string containing API token as a single parameter to streamline settings object instantiation:
```csharp
using Mailtrap.Configuration.Models;
...
var config = new MailtrapClientOptions("<API_TOKEN>");
...
```  

Other parameters have reasonable defaults:
 - Endpoints are pointing to the production instances
 - Serialization is configured to minify JSON to reduce the network traffic

But in case of need any of these can be changed to custom values during object construction or using configuration binding.
```cs
using Mailtrap.Configuration.Models;

...

var config = new MailtrapClientOptions("<API_TOKEN>")
{
    SendEndpoint = new MailtrapClientEndpointOptions("https://api.mailtrap.io/v3-alpha/send"),
    TestEndpoint = new MailtrapClientEndpointOptions("https://localhost:8080/sandbox"),
    Serialization = new MailtrapClientSerializationOptions
    {
        PrettyJson = true
    }
};
```



## Dependency Injection
When using hosting model from MS, Mailtrap API client uses [Options Pattern](https://learn.microsoft.com/dotnet/core/extensions/options) for configuration under the hood.  
Any of available approaches to configure `IOptions<MailtrapClientOptions>` in the DI container can be used and client will consume them.  
Meanwhile, library provides few handy shortcut extensions to simplify configuring Mailtrap API client in @Microsoft.Extensions.DependencyInjection.IServiceCollection.  

### Configuration by @Microsoft.Extensions.Configuration.IConfiguration abstraction
Hosting model supports a number of configuration providers out-of-the-box:
 - configuration files
 - environment variables
 - command line arguments
 - etc.

More details can be found [here](https://learn.microsoft.com/dotnet/core/extensions/configuration)

Assuming the following Mailtrap configuration in `appsettings.json`
```json
"Mailtrap": {
  "Authentication": {
    "ApiToken": "<API_TOKEN>"
  },
  "SendEndpoint": {
    "BaseUrl": "https://api.mailtrap.io/v3/send"
  },
  "Serialization": {
    "PrettyJson": true
  }
}
```

Then section from configuration can be loaded and used to configure Mailtrap API client with it:
```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Mailtrap;

...

// Creating host builder with defaults
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);
        
// Loading configuration section
IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

// Adding Mailtrap API client to the container
hostBuilder.Services.AddMailtrapClient(config);

// Building the host
IHost host = hostBuilder.Build();
```

Alternatively, more granular configuration flow can be used:
```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Mailtrap;

...

// Creating host builder with defaults
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

// Loading configuration section
IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

// Configuring client options
hostBuilder.Services.Configure<MailtrapClientOptions>(config);

// Do any additional custom configuration, overrides, etc.
hostBuilder.Services.PostConfigure<MailtrapClientOptions>(options =>
{
    options.Authentication.ApiToken = Environment.GetEnvironmentVariable("MAILTRAP_TOKEN");
});

// Adding Mailtrap API client core services to the container
// This won't add nor configure HttpClient, thus it has to be done separately
hostBuilder.Services.AddMailtrapServices();

// Adding and optionally configuring HttpClient
hostBuilder.Services
    .AddHttpClient(Options.DefaultName)
    .AddStandardResilienceHandler()
    .AddExtendedHttpClientLogging();

// Building the host
IHost host = hostBuilder.Build();
```

### Configuration by delegate
Mailtrap API client settings can be set up programmatically, using extension overload accepting configuration delegate:
```csharp
using Microsoft.Extensions.Hosting;
using Mailtrap;

...

// Creating host builder with defaults
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);
        
// Adding Mailtrap API client to the container
hostBuilder.Services.AddMailtrapClient((MailtrapClientOptions options) =>
{
    options.Authentication.ApiToken = "<API_TOKEN>";
    options.Serialization.PrettyJson = true;
});

// Building the host
IHost host = hostBuilder.Build();
```

### Configuration by @Mailtrap.Configuration.Models.MailtrapClientOptions instance
Similarly to the previous section, configuration can be done by passing pre-created instance of @Mailtrap.Configuration.Models.MailtrapClientOptions:
```csharp
using Microsoft.Extensions.Hosting;
using Mailtrap;

...

// Creating host builder with defaults
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

// Creating new instance of `MailtrapClientOptions`
var config = new MailtrapClientOptions("<API_TOKEN>");
        
// Adding Mailtrap API client to the container
hostBuilder.Services.AddMailtrapClient(config);

// Building the host
IHost host = hostBuilder.Build();
```

### @System.Net.Http.HttpClient configuration
All `AddMailtrapClient` extension method overloads return @Microsoft.Extensions.DependencyInjection.IHttpClientBuilder?displayProperty=name instance.  
Thus a fine-grain tuning of the @System.Net.Http.HttpClient configuration can be done:
```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Mailtrap;

...

// Creating host builder with defaults
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);
        
// Loading configuration section
IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

// Adding Mailtrap API client to the container
IHttpClientBuilder httpClientBuilder = hostBuilder.Services.AddMailtrapClient(config);

// Do any required HttpClient configuration
// httpClientBuilder.AddStandardResilienceHandler();
// etc.

// Building the host
IHost host = hostBuilder.Build();
```

### See Also
Additional samples for client configuration within DI container can be found on [GitHub](https://github.com/railsware/mailtrap-dotnet/blob/docs/main/src/samples/Mailtrap.Samples.DependencyInjection/Program.cs)




## Standalone factory
While DI pattern is recommended approach to configure and use Mailtrap API client, alternatively @Mailtrap.MailtrapClientFactory can be used to spawn client instances, when usage of DI container isn't possible or desired.  
In most cases factory configuration is pretty similar to the DI container one.


### Basic usage
In the simplest scenario getting client is as simple as the following:
```csharp
using Mailtrap;

...

// Creating factory instance
using var factory = new MailtrapClientFactory("<API_TOKEN>");

// Spawning client
IMailtrapClient client = factory.CreateClient();
```

> [!NOTE]  
> Please consider that @Mailtrap.MailtrapClientFactory implements @System.IDisposable interface and must be disposed properly after use.  


### Configuring with @Mailtrap.Configuration.Models.MailtrapClientOptions instance
Alternatively, the same way as with DI container, factory can be configured using pre-created instance of @Mailtrap.Configuration.Models.MailtrapClientOptions:
```csharp
using Mailtrap;

...

// Creating new instance of `MailtrapClientOptions`
var config = new MailtrapClientOptions("<API_TOKEN>");
config.SendEndpoint.BaseUrl = "https://api.mailtrap.io/v3-alpha/send";
config.Serialization.PrettyJson = true;

// Creating factory instance        
using var factory = new MailtrapClientFactory("<API_TOKEN>");

// Spawning Mailtrap API client
IMailtrapClient client = factory.CreateClient();
```

### Advanced @System.Net.Http.HttpClient configuration
Optionally, a delegate for advanced HTTP pipeline configuration can be passed as a second parameter to factory constructor:
```csharp
using Mailtrap;

...

// Creating factory instance
using var factory = new MailtrapClientFactory("<API_TOKEN>", (IHttpClientBuilder builder) =>
{
    // Do any required HttpClient configuration
    // builder.AddStandardResilienceHandler();
    // etc.
});

// Spawning Mailtrap API client
IMailtrapClient client = factory.CreateClient();
```

As an alternative to the aforementioned scenario, external pre-configured instance of @System.Net.Http.HttpClient can be passed instead of delegate.
```csharp
using System.Net.Http;
using Mailtrap;

...

// Assuming there is some already existing instance.
using var httpClient = new HttpClient();

// Creating factory instance
using var factory = new MailtrapClientFactory("<API_TOKEN>", httpClient);

// Spawning Mailtrap API client
IMailtrapClient client = factory.CreateClient();
```


### See Also
Additional samples of the Mailtrap API client factory configuration and usage can be found on [GitHub](https://github.com/railsware/mailtrap-dotnet/blob/docs/main/src/samples/Mailtrap.Samples.BasicUsage/Program.cs)
