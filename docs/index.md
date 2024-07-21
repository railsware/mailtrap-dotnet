---
_layout: landing
---

# Official Mailtrap .NET Client

Welcome to the documentation portal for official .NET client for [Mailtrap](https://mailtrap.io/)!


## Quick Start


1. Register new or log into existing account at [mailtrap.io](https://mailtrap.io/register/signup?ref=maitrap-dotnet)

1. Obtain [API token](https://mailtrap.io/api-tokens)


1. Ensure your project targets .NET implementation which implements [**.NET Standard 2.0**](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions) specification


1. Install Maitrap package from NuGet  
   ```console
   dotnet add package Mailtrap
   ```

1. Add obtained API token to application host configuration  
   E.g. *secrets.json* (recommended for development environment)
   ```json
    {
      "Mailtrap:Authentication:ApiToken": "<TOKEN>"
    }
   ```

   Or *appsettings.json* ()
   ```json
   "Mailtrap": {
      "Authentication": {
        "ApiToken": "<TOKEN>"
      }
   }
   ```


