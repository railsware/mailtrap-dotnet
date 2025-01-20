![Mailtrap](assets/img/mailtrap-logo.svg)

[![NuGet Version](https://img.shields.io/nuget/v/Railsware.Mailtrap?label=NuGet)](https://www.nuget.org/packages/Railsware.Mailtrap)
[![CI](https://github.com/railsware/mailtrap-dotnet/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/railsware/mailtrap-dotnet/actions/workflows/build.yml)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/railsware/mailtrap-dotnet/blob/main/LICENSE.md)

# Official Mailtrap .NET Client
Welcome to the official [Mailtrap](https://mailtrap.io/) .NET Client repository.  
This client allows you to quickly and easily integrate your .NET application with **v2.0** of the [Mailtrap API](https://api-docs.mailtrap.io/docs/mailtrap-api-docs/5tjdeg9545058-mailtrap-api).


## Quick Start
The following few simple steps will bring Mailtrap API functionality into your .NET project.

### Prerequisites
- Please ensure your project targets .NET implementation which supports [**.NET Standard 2.0**](https://dotnet.microsoft.com/platform/dotnet-standard#versions) specification.

- Register new or log into existing account at [mailtrap.io](https://mailtrap.io/register/signup?ref=maitrap-dotnet)

- Obtain [API token](https://mailtrap.io/api-tokens)  
  You can use one of the existing or create a new one.

### Install
Install `Mailtrap` package from NuGet  

  > **TODO**  
  > This is an example command, to be updated once the package is published.  

  ```console
  dotnet add package Mailtrap
  ```

### Configure
Add Mailtrap services to the DI container.

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

### Use
Now you can inject `IMailtrapClient` instance in any application service and use it to make API calls.

```csharp
using Mailtrap;
using Mailtrap.Emails.Requests;
using Mailtrap.Emails.Responses;
   

namespace MyAwesomeProject;


public sealed class SendEmailService : ISendEmailService
{
    private readonly IMailtrapClient _mailtrapClient;


    public SendEmailService(IMailtrapClient mailtrapClient)
    {
        _mailtrapClient = client;
    }


    public async Task DoWork()
    {
        try 
        {
            SendEmailRequest request = SendEmailRequest
                .Create()
                .From("john.doe@demomailtrap.com", "John Doe")
                .To("hero.bill@galaxy.net")
                .Subject("Invitation to Earth")
                .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

            SendEmailResponse response = await _mailtrapClient
                .Email()
                .Send(request);
                
            string messageId = response.MessageIds.FirstOrDefault();
        }
        catch (MailtrapException mtex)
        {
            // handle Mailtrap API specific exceptions
        }
        catch (OperationCancelledException ocex)
        {
            // handle cancellation
        }
        catch (Exception ex)
        {
            // handle other exceptions
        }   
    }
}
```

## Documentation
Please visit [Documentation Portal](https://railsware.github.io/mailtrap-dotnet/) for detailed setup, configuration and usage instructions.  
A bunch of examples is available [here](https://github.com/railsware/mailtrap-dotnet/tree/main/examples).


<!-- ## Contributing
We believe in the power of OSS and welcome any contributions to the library.  
Please refer to [Contributing Guide](https://github.com/railsware/mailtrap-dotnet/tree/main?tab=contrib-ov-file#readme) for details. -->

## License
Licensed under the [MIT License](https://github.com/railsware/mailtrap-dotnet/tree/main?tab=MIT-1-ov-file#readme).