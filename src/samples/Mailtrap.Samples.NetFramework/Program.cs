// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


#nullable enable


using System;
using System.Linq;
using System.Threading.Tasks;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;


namespace Mailtrap.Samples.NetFramework;


internal class Program
{
    static async Task Main()
    {
        try
        {
            // For sure you should not hardcode apiKey for security reasons, and use environment variables
            // or configuration files instead. But for the sake of simplicity, we will use hardcoded value in this example.
            var apiKey = "<API_KEY>";

            SendEmailRequest request = SendEmailRequestBuilder
                .Email()
                .From("john.doe@demomailtrap.com", "John Doe")
                .To("hero.bill@galaxy.net")
                .Subject("Invitation to Earth")
                .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

            // Instances of Mailtrap API Client, created using simplified constructors,
            // should be used as singletons - since they are using HttpClientFactory under the hood.
            // Creating/disposing instances of MailtrapClient for each request is not recommended,
            // as it could lead to port exhaustion.
            // But for simplicity, we will use it as unit-of-work in this particular example.

            using var client = new MailtrapClient(apiKey);

            SendEmailResponse? response = await client.SendAsync(request).ConfigureAwait(false);

            Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while sending email:\n{0}", ex);
            Environment.FailFast(ex.Message);
            throw;
        }
    }
}
