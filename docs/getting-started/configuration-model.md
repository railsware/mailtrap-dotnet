---
uid: configuration-model
---


# Configuration Model

[!INCLUDE [api-token-caution](../includes/api-token-caution.md)]

Regardless of the configuration approach used for Mailtrap API client setup, all of them are using unified configuration model @Mailtrap.Configuration.Models.MailtrapClientOptions under the hood.

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


## Authentication Configuration
@Mailtrap.Configuration.Models.MailtrapClientAuthenticationOptions class represents authorization and authentication configuration used by Mailtrap API client.

@Mailtrap.Configuration.Models.MailtrapClientAuthenticationOptions.ApiToken is used to set a token to authorize client requests to Mailtrap API.  
This is the only required setting, that needs to be set explicitly, since by default it is set to empty string, which isn't a valid value and will throw an exception if left unchanged.


## Endpoint Configuration
@Mailtrap.Configuration.Models.MailtrapClientOptions contains few separate endpoint configurations for different email send channels/API features.
- @Mailtrap.Configuration.Models.MailtrapClientOptions.SendEndpoint
- @Mailtrap.Configuration.Models.MailtrapClientOptions.BulkEndpoint
- @Mailtrap.Configuration.Models.MailtrapClientOptions.TestEndpoint
- etc.

All of those are @Mailtrap.Configuration.Models.MailtrapClientEndpointOptions instances, which can be configured individually.

@Mailtrap.Configuration.Models.MailtrapClientEndpointOptions.BaseUrl is used to specify base URL for endpoint. It should be a valid absolute URI.


## Serialization Configuration
@Mailtrap.Configuration.Models.MailtrapClientSerializationOptions class represents serialization configuration used by Mailtrap API client.

@Mailtrap.Configuration.Models.MailtrapClientSerializationOptions.PrettyJson flag can be opted-in to produce non-minified JSON for outgoing HTTP requests, which can be helpful for debugging and log analysis.

By default it is set to `false`, and JSON that is sent in HTTP requests is minified:
```json
{"to":[{"email":"john_doe@example.com","name":"John Doe"}],"from":{"email":"sales@example.com","name":"Example Sales Team"},...}
```

But when opted-in, outgoing HTTP request body will contain human-friendly JSON:
```json
{
  "to": [
    {
      "email": "john_doe@example.com",
      "name": "John Doe"
    }
  ],
  "from": {
    "email": "sales@example.com",
    "name": "Example Sales Team"
  },
  ...
}
```


## What's next
If you are using DI container in your application, please visit [this article](xref:configuration-client-di) for detailed instructions how to configure and inject Mailtrap API client.

Alternatively, you can use [standalone factory](xref:configuration-client-factory) for configuring and spawning Mailtrap API client instances.
