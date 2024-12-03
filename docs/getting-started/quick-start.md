---
uid: quick-start
---


# Quick Start
The following few simple steps will bring Mailtrap API functionality into your .NET project.


## Prerequisites
Please ensure your project targets .NET implementation which supports [**.NET Standard 2.0**](https://dotnet.microsoft.com/platform/dotnet-standard#versions) specification.


## Setup
- Install `Mailtrap` package from NuGet  
  > **TODO**  
  > This is an example command, to be updated once the package is published.  
  ```console
  dotnet add package Mailtrap
  ```

- Register new or log into existing account at [mailtrap.io](https://mailtrap.io/register/signup?ref=maitrap-dotnet)

- Obtain [API token](https://mailtrap.io/api-tokens)  
  You can use one of the existing or create a new one.


## Configure
Mailtrap API client supports few configuration options.

### [DI Container](#tab/di)
If you are using a hosting model from Microsoft in your app ([`IHostBuilder`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostbuilder), [`IWebHostBuilder`](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder), etc.), you can simply add Mailtrap API client to host DI container:
```csharp
using Mailtrap;
   
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
      options.ApiToken = "<API_TOKEN>";
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


### [Factory](#tab/factory)
If you want to use Mailtrap API client without DI container, than you can use @Mailtrap.MailtrapClientFactory for spawning @Mailtrap.IMailtrapClient instances:
```csharp
using Mailtrap;

...

// Definitely, hardcoding a token isn't a good idea.
// This example uses it for simplicity, but in real-world scenarios
// you should consider more secure approaches for storing secrets.
using var factory = new MailtrapClientFactory("<API_TOKEN>");

IMailtrapClient mailtrapClient = factory.CreateClient();
```

Factory is intended to be used as singleton in the typical scenario, while produced @Mailtrap.IMailtrapClient instances are lightweight and can be used in any manner.

[!INCLUDE [factory-disposal-caution](../includes/factory-disposal-caution.md)]

---

> [!NOTE]  
> The detailed configuration guide with more advanced setup scenarios can be found [here](xref:configuration-model).


## Use
Finally, when you have obtained @Mailtrap.IMailtrapClient instance, you can use it to make API calls:
```csharp
using Mailtrap.Emails.Requests;

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
      .Email()
      .Send(request);
      
   string messageId = response.MessageIds.FirstOrDefault();
}
catch (MailtrapApiException mtex)
{
   // handle Mailtrap specific exceptions
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


## What's next
[!INCLUDE [configuration-section-link](../includes/configuration-section-link.md)] for more configuration examples.

[!INCLUDE [cookbook-link](../includes/cookbook-link.md)]

[!INCLUDE [examples-link](../includes/examples-link.md)]

[!INCLUDE [api-reference-link](../includes/api-reference-link.md)]
