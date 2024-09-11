---
uid: configuration-model
---


# Configuration Model

[!INCLUDE [api-token-caution](../includes/api-token-caution.md)]

Regardless of the configuration approach used for Mailtrap API client setup, all of them are using unified configuration model @Mailtrap.Configuration.MailtrapClientOptions under the hood.

In the common case, the only required configuration setting is @Mailtrap.Configuration.MailtrapClientOptions.ApiToken.  
Default is empty string, which will cause configuration validation to fail if left untouched.  

There is a dedicated [constructor](xref:Mailtrap.Configuration.MailtrapClientOptions.%23ctor(System.String)), that takes string containing API token as a single parameter to streamline settings object instantiation:
```csharp
using Mailtrap.Configuration.Models;

...

var config = new MailtrapClientOptions("<API_TOKEN>");
```  

Other parameters receive reasonable defaults:
 - JSON minification is enabled
 - Default method for sending emails is set to transactional.

But in case of need they can be changed to custom values during object construction or using configuration binding.
```cs
using Mailtrap.Configuration.Models;

...

var config = new MailtrapClientOptions("<API_TOKEN>")
{
    PrettyJson = true,
    UseBulkApi = true
};
```


## Authentication
@Mailtrap.Configuration.MailtrapClientOptions.ApiToken is used to set a token to authorize client requests to Mailtrap API.  
This is the only required setting, that needs to be set explicitly, since by default it is set to empty string,
which isn't a valid value and will throw an exception if left unchanged.


## Default Send Channel
A combination of @Mailtrap.Configuration.MailtrapClientOptions.UseBulkApi and @Mailtrap.Configuration.MailtrapClientOptions.InboxId parameters
is used to define default channel for sent emails.  

If @Mailtrap.Configuration.MailtrapClientOptions.InboxId contains valid Inbox ID, default send channel will be set to test,
and all emails sent through @Mailtrap.IMailtrapClient.Email() will be routed to the specified inbox.

In case Inbox is not specified (set to empty string or null), default send channel will be set to transactional or bulk,
depending on the @Mailtrap.Configuration.MailtrapClientOptions.UseBulkApi flag.


## Serialization
@Mailtrap.Configuration.MailtrapClientOptions.PrettyJson flag can be opted-in to produce pretty JSON for outgoing HTTP requests,
which can be helpful for debugging and log analysis.

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
