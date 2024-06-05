// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;


try
{
    var apiKey = "<API_KEY>";
    var request = EmailSendApiRequestBuilder
        .Create()
        .WithSender("john.doe@demomailtrap.com", "John Doe")
        .WithSubject("Invitation to Earth")
        .WithRecipient("hero.bill@galaxy.net")
        .WithTextBody("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

    var client = new MailtrapApiClient(apiKey, httpClientBuilder =>
    {
        httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new HttpClientHandler()
            {
                Proxy = new WebProxy("proxy.mailtrap.io", 8080)
            };
        });
    });
    var response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}
catch (Exception ex)
{
    Console.WriteLine("Error during send: {0}", ex);
    throw;
}


