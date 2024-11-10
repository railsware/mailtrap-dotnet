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
    public async Task GetUsage_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Get;
        var accountId = random.NextLong();
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(
                UrlSegmentsTestConstants.BillingSegment,
                UrlSegmentsTestConstants.BillingUsageSegment)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var responseString = await File.ReadAllTextAsync(Path.Combine("billing", "getUsage-success.json"));
        using var responseContent = new StringContent(responseString);

        using var mockHttp = new MockHttpMessageHandler();
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
            .GetUsage();


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }

    [Test]
    public async Task GetUsage_Forbidden()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Get;
        var accountId = random.NextLong();
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(
                UrlSegmentsTestConstants.BillingSegment,
                UrlSegmentsTestConstants.BillingUsageSegment)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var responseString = await File.ReadAllTextAsync(Path.Combine("billing", "getUsage-forbidden.json"));
        using var responseContent = new StringContent(responseString);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.Forbidden, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();

        var act = () => client
            .Account(accountId)
            .Billing()
            .GetUsage();


        // Assert
        await act.Should()
            .ThrowAsync<HttpRequestFailedException>()
            .WithMessage("*'Access forbidden'*");

        mockHttp.VerifyNoOutstandingExpectation();
    }
}
