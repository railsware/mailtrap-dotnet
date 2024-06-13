// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;
using Mailtrap.Email.Requests;


try
{
    // For sure you should not hardcode apiKey for security reasons, and use environment variables or configuration files instead.
    // But for the sake of simplicity, we will use hardcoded value in this example.
    var apiKey = "<API_KEY>";

    var request = SendEmailApiRequestBuilder
        .Create<RegularSendEmailApiRequest>()
        .WithSender("john.doe@demomailtrap.com", "John Doe")
        .WithSubject("Invitation to Earth")
        .WithRecipient("hero.bill@galaxy.net")
        .WithTextBody("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

    using var client = new MailtrapApiClient(apiKey);
    //{
    //    httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
    //    {
    //        return new HttpClientHandler()
    //        {
    //            Proxy = new WebProxy("proxy.mailtrap.io", 8080)
    //        };
    //    });
    //});
    var response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}
catch (Exception ex)
{
    Console.WriteLine("Error during send: {0}", ex);
    throw;
}


