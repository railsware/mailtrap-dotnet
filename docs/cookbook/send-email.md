---
uid: send-email
---


# Sending Emails
This article covers different scenarios of forming and sending emails using Mailtrap API client.


## Creating @Mailtrap.Email.Requests.SendEmailRequest
Sending email API uses @Mailtrap.Email.Requests.SendEmailRequest object to create a payload for the API request.  
Library provides two ways for creating instances of it.

### Fluent builder
There is a set of extensions in @Mailtrap.Email.Requests.SendEmailRequestBuilder, which allow you to create requests in a fluent style:
```csharp
using Mailtrap.Email.Requests;

...

var request = SendEmailRequest
    .Create()
    .From("john.doe@demomailtrap.com", "John Doe")
    .To("hero.bill@galaxy.net")
    .Cc("star.lord@galaxy.net")
    .Subject("Invitation to Earth")
    .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");
...
```

### Regular initialization
Alternatively, you can use object initialization and setup fields as usual:
```csharp
using Mailtrap.Email.Requests;

...

var from = new EmailAddress("john.doe@demomailtrap.com", "John Doe");

var request = new SendEmailRequest
{
    From = from,
    Subject = "Invitation to Earth",
    TextBody = "Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John."
};

// You can specify up to 1000 recipients in each of To, Cc and Bcc fields.
// At least one of recipient collections must contain at least one recipient.
var to = new EmailAddress("hero.bill@galaxy.net");
request.To.Add(to);

var cc = new EmailAddress("star.lord@galaxy.net");
request.Cc.Add(cc);

request.Bcc.Add(from);
...
```

## Attaching files
You can attach files to emails, both for inlining (embedding) or as a standalone downloadable file:
```csharp
using Mailtrap.Email.Requests;

...

var request = SendEmailRequest
    .Create()
    .From("john.doe@demomailtrap.com", "John Doe")
    .To("hero.bill@galaxy.net")
    .Subject("Invitation to Earth")
    .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

var filePath = @"C:\files\preview.pdf";
var fileName = "preview.pdf";
var bytes = File.ReadAllBytes(filePath);
var fileContent = Convert.ToBase64String(bytes);

request.Attach(
    content: fileContent,
    filename: fileName,
    dispositionType: DispositionType.Attachment, // Downloadable
    mimeType: MediaTypeNames.Application.Pdf);

filePath = @"C:\files\logo.png";
fileName = "logo.png";
bytes = File.ReadAllBytes(filePath);
fileContent = Convert.ToBase64String(bytes);

request.Attach(
    content: fileContent,
    filename: fileName,
    dispositionType: DispositionType.Inline, // For embedding
    mimeType: MediaTypeNames.Image.Png,
    contentId: "logo_1");
```


## Email from template
There is a possibility to create emails from predefined templates.  
You can create a template and obtain its ID [here](https://mailtrap.io/email_templates/).  
Then you can use it in emails:
```csharp
using Mailtrap.Email.Requests;

...

var request = SendEmailRequest
    .Create()
    .From("john.doe@demomailtrap.com", "John Doe")
    .To("hero.bill@galaxy.net")
    .Template("60dca11e-0bc2-42ea-91a8-5ff196acb3f9") // ID of template obtained from https://mailtrap.io/email_templates/
    .TemplateVariables(new Dictionary<string, string>
    {
        { "name", "Bill" },
        { "sender", "John" }
    });
...
```

## Kitchen sink
Just to give an overview of all possible settings:
```csharp
using Mailtrap.Email.Extensions;

...

// Create new request
var request = SendEmailRequest.Create();

// Sender (Display name is optional)
request.From("john.doe@demomailtrap.com", "John Doe");

// You can use simple email as recipient
request.To("hero.bill@galaxy.net");

// Add additional recipients by subsequent calls (Display name is optional)
request.To("steel.rat@galaxy.net", "James");

// Alternatively, existing EmailAddress instance can be used.
var vipEmail = new EmailAddress("star.lord@galaxy.net");
request.Cc(vipEmail);

// Alternatively, you could pass a collection at once
request.Bcc(
    new EmailAddress("first@domain.com"),
    new EmailAddress("second@domain.com"));

// Subject
request.Subject("Invitation to Earth");

// HTML body.
// At least one of Text or Html body must be specified.
request.Html(
    "<h2>Greetings, Bill!</h2>" +
    "<p>It will be a great pleasure to see you on our blue planet next weekend.</p>" +
    "<p>Regards,<br/>" +
    "John</p>");

// Plain text body.
// Will be used in case HTML body is missing or is not supported by the recipient.
request.Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

// Categorize
request.Category("Invitation");

// Add an attachment
var filePath = @"C:\files\preview.pdf";
var fileName = "preview.pdf";
var bytes = File.ReadAllBytes(filePath);
var fileContent = Convert.ToBase64String(bytes);

request.Attach(
    content: fileContent,
    filename: fileName,
    dispositionType: DispositionType.Attachment,
    mimeType: MediaTypeNames.Application.Pdf);

// Add custom variables
request.CustomVariable("var_key", "var_value");

// Adding few at once also supported
request.CustomVariable(
    new("var_key_1", "var_value_1"),
    new("var_key_2", "var_value_2"),
    new("var_key_3", "var_value_3"));

// Add custom headers
request.Header("X-Custom-Header", "Custom Value");

// Adding few at once supported as well
request.Header(
    new("X-Custom-Header-1", "Custom Value 1"),
    new("X-Custom-Header-2", "Custom Value 2"),
    new("X-Custom-Header-3", "Custom Value 3"));
```


## @Mailtrap.Email.Requests.SendEmailRequest validation
After creating a request instance, it is recommended to perform a validation on a client side to ensure sending won't throw validation exceptions and to minimize unnecessary HTTP round-trips.  
There is a couple of extension methods defined in @Mailtrap.Email.Extensions.SendEmailRequestValidationExtensions which can help:  
```csharp
using Mailtrap.Email.Extensions;

...

var request = new SendEmailRequest();

var isRequestValid = request.IsValid(); // Returns a boolean flag

if (isRequestValid)
{
    // Send
}
else
{
    // Handle invalid request
}
```

Alternatively, you can use extension that throws @System.ArgumentException if validation fails:
```csharp
using Mailtrap.Email.Extensions;

...

try 
{
    var request = new SendEmailRequest();

    request.Validate(); // Will throw if request isn't valid.
}
catch (ArgumentException aex)
{
    // Handle validation issues
}
```

> [!NOTE]  
> Client implementation uses the latter approach internally, to ensure request validity before sending.  


## Using send API
Finally, after you have formed a valid request, you can send it:
```csharp
using Mailtrap;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;
using Mailtrap.Email.Extensions;

...


private readonly IMailtrapClient _mailtrapClient;

try 
{
    SendEmailRequest request = SendEmailRequest
        .Create()
        .From("john.doe@demomailtrap.com", "John Doe")
        .To("hero.bill@galaxy.net")
        .Subject("Invitation to Earth")
        .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

    if (request.IsValid())
    {
        SendEmailResponse response = await _mailtrapClient
            .SendAsync(request)
            .ConfigureAwait(false);
      
        MessageId messageId = response.MessageIds.FirstOrDefault(MessageId.Empty);
    }
    else
    {
        // handle validation issues
    }
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

## See also
More examples available in the [samples folder](https://github.com/railsware/mailtrap-dotnet/tree/main/src/samples) on GitHub.
