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
                .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

            using var factory = new MailtrapClientFactory(apiKey);

            SendEmailResponse? response = await factory.CreateClient().SendAsync(request).ConfigureAwait(false);

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
