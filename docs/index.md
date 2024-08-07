# Official Mailtrap .NET Client

Welcome to the documentation portal for official .NET client for [Mailtrap](https://mailtrap.io/)!

This client allows you to quickly and easily integrate Mailtrap API into your .NET application.


## Quick Start

### Prerequisites
Please ensure your project targets .NET implementation which implements [**.NET Standard 2.0**](https://dotnet.microsoft.com/platform/dotnet-standard#versions) specification.

### Setup
- Register new or log into existing account at [mailtrap.io](https://mailtrap.io/register/signup?ref=maitrap-dotnet)

- Obtain [API token](https://mailtrap.io/api-tokens)

- Install Mailtrap package from NuGet  
  > **TODO**  
  > This is an example command, to be updated once the package is published.  
  ```console
  dotnet add package Mailtrap
  ```

### Configure
a) If you are using a hosting model from Microsoft in your app ([`IHostBuilder`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostbuilder), [`IWebHostBuilder`](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder), etc.), you can simply add Mailtrap API client to host DI container:
   ```csharp
   using Mailtrap.Extensions.DependencyInjection;
   
   ...
   
   hostBuilder.ConfigureServices((context, services) =>
   {
      services.AddMailtrapClient(options =>
      {
         // Definitely, hardcoding a token isn't a good idea.
         // This example uses it for simplicity, but in real-world scenarios
         // you should consider more secure approaches for storing secrets.
         
         // Environment variables can be an option, as well as other solutions:
         // https://learn.microsoft.com/aspnet/core/security/app-secrets
         // or https://learn.microsoft.com/aspnet/core/security/key-vault-configuration
         options.Authentication.ApiToken = "<YOUR-API-TOKEN>";
      });
   });   
   ```
   And after that you can inject @Mailtrap.IMailtrapClient instances in any application service:
   ```csharp
   using Mailtrap;
   
   ...

   public SomeCoolApplicationService(IMailtrapClient client)
   {
      mailtrapClient = client;
   }
   ```

   b) If you want to use Mailtrap API client without DI container, than you can use @Mailtrap.MailtrapClientFactory for spawning @Mailtrap.IMailtrapClient instances:
   ```csharp
   using Mailtrap;

   ...

   // Definitely, hardcoding a token isn't a good idea.
   // This example uses it for simplicity, but in real-world scenarios
   // you should consider more secure approaches for storing secrets.
   using var factory = new MailtrapClientFactory("<YOUR-API-TOKEN>");

   IMailtrapClient mailtrapClient = factory.CreateClient();
   ```

   Factory is intended to be used as singleton in the typical scenario, while produced @Mailtrap.IMailtrapClient instances are lightweight and can be used in any manner.

   > [!IMPORTANT]
   > Please consider that @Mailtrap.MailtrapClientFactory implements @System.IDisposable interface and must be disposed properly after use.  


### Use
Finally, when you have obtained @Mailtrap.IMailtrapClient instance, you can use it to make API calls:
```csharp
using Mailtrap.Email.Requests;
...
try 
{
   SendEmailRequest request = SendEmailRequest
      .Create()
      .From("john.doe@demomailtrap.com", "John Doe")
      .To("hero.bill@galaxy.net")
      .Subject("Invitation to Earth")
      .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

   SendEmailResponse response = await mailtrapClient
      .SendAsync(request)
      .ConfigureAwait(false);
      
   MessageId messageId = response.MessageIds.FirstOrDefault();
}
catch (ArgumentException aex)
{
   // handle request validation issues
}
catch (JsonException jex)
{
   // handle serialization issues
}
catch (HttpRequestException hrex)
{
   // handle HTTP errors
}
catch (OperationCancelledException ocex)
{
   // handle cancellation
}
catch (Exception ex)
{
   // handle other exceptions
}   
```

### What's next
Please visit [Cookbook](xref:configure) section for more configuration and usage examples.  

Also a bunch of samples is available in the [Source Repository](https://github.com/railsware/mailtrap-dotnet/tree/main/src/samples).  

Detailed API reference is available [here](xref:Mailtrap).


<!-- ## Contributing
We believe in the power of OSS and welcome contribution to the library.  
Please refer to [Contributing Guide](https://github.com/railsware/mailtrap-dotnet/tree/main?tab=contrib-ov-file#readme) for details. -->


## License
Licensed under the [MIT License](https://github.com/railsware/mailtrap-dotnet/tree/main?tab=MIT-1-ov-file#readme).