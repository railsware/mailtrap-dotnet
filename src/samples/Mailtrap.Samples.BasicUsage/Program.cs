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

    using var mockEndpointClient = new MailtrapApiClient("https://mock.mailtrap.io/", apiKey);
    var responseFromMock = await mockEndpointClient.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully to the mock endpoint. MessageId: {0}", responseFromMock?.MessageIds?.FirstOrDefault());

    using var client = new MailtrapApiClient(apiKey);
    var response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}
catch (Exception ex)
{
    Console.WriteLine("Error during send: {0}", ex);
    throw;
}


