// -----------------------------------------------------------------------
// <copyright file="BillingIntegrationTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.Billing;


[TestFixture]
internal sealed class BillingIntegrationTests
{
    [Test]
    public async Task GetAll()
    {
        // Arrange
        using var mockHttp = new MockHttpMessageHandler();
        var httpMethod = HttpMethod.Get;
        var accountId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(
                UrlSegmentsTestConstants.BillingSegment,
                UrlSegmentsTestConstants.BillingUsageSegment)
            .AbsoluteUri;
        var token = TestContext.CurrentContext.Random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var response = new BillingUsage();
        using var responseContent = JsonContent.Create(response);

        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(accountId)
            .Billing()
            .GetUsage()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);
    }
}
