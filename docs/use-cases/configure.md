# Configuration
This article covers different configuration options for Mailtrap API client.

> [!WARNING]  
> Examples below could contain API token specified as a plain text in code or configuration files.  
> This is not a recommended approach and is used only for brevity.
>
> In production scenarios it is highly recommended to use more secure approaches to store sensitive configuration, such as:
> - Environment variables  
> https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets#environment-variables
> - Secrets Manager  
> https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets#secret-manager
> - Azure Key Vault  
> https://learn.microsoft.com/en-us/aspnet/core/security/key-vault-configuration
> - etc.


## Dependency Injection
When using hosting model from MS, Mailtrap API client uses [Options Pattern](https://learn.microsoft.com/en-us/dotnet/core/extensions/options) for configuration under the hood.  
You can use any of available approaches to configure `IOptions<MailtrapClientOptions>` in the DI container and client will consume them.  
Meanwhile, library provides few handy shortcut extensions to simplify configuring Mailtrap API client in `IServiceCollection`.  

### Configuration by `IConfiguration` abstraction
Hosting model supports a number of configuration providers out-of-the-box:
 - configuration files
 - environment variables
 - command line arguments
 - etc.

More details can be found [here](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration)

Assuming you have Mailtrap configuration in `appsettings.json`
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

Then you can load section from configuration and configure Mailtrap API client with it:
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

Alternatively, you can use more granular configuration flow:
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
// This won't add nor configure HttpClient, thus you will need to do that separately
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
You can setup Mailtrap API client setting programmatically, using extension overload accepting configuration delegate:
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

### Configuration by `MailtrapClientOptions` instance
Similarly to the previous section, configuration can be done by passing pre-created `MailtrapClientOptions` instance:
```csharp
using Microsoft.Extensions.Hosting;
using Mailtrap;

...

// Creating host builder with defaults
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

// Creating new instance of `MailtrapClientOptions`
MailtrapClientOptions config = new MailtrapClientOptions("<API_TOKEN>");
        
// Adding Mailtrap API client to the container
hostBuilder.Services.AddMailtrapClient(config);

// Building the host
IHost host = hostBuilder.Build();
```

### `HttpClient` configuration
All `AddMailtrapClient` extension method overloads return [IHttpClientBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihttpclientbuilder) instance.  
Thus you can easily do a fine-grain tuning of the `HttpClient` configuration:
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
Additional samples can be found on [GitHub](https://github.com/railsware/mailtrap-dotnet/blob/docs/main/src/samples/Mailtrap.Samples.DependencyInjection/Program.cs)


## Standalone factory
While DI pattern is recommended approach to configure and use Mailtrap API client, alternatively `MailtrapClientFactory` can be used to spawn client instances, when usage of DI container isn't possible or desired.  
In most cases factory configuration is similar to DI container one.

### Basic usage
In the simplest scenario getting client is as simple as the following:
```csharp
using Mailtrap;

...

using var factory = new MailtrapClientFactory("<API_TOKEN>");

IMailtrapClient client = factory.CreateClient();
```

Please consider that default `MailtrapClientFactory` implements `IDisposable` and must be disposed properly after use.  


### See Also
Additional samples can be found on [GitHub](https://github.com/railsware/mailtrap-dotnet/blob/docs/main/src/samples/Mailtrap.Samples.BasicUsage/Program.cs)
