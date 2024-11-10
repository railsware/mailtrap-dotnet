// -----------------------------------------------------------------------
// <copyright file="PermissionsIntegrationTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.Permissions;


[TestFixture]
internal sealed class PermissionsIntegrationTests
{
    [Test]
    public async Task GetForResources_Success()
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
                UrlSegmentsTestConstants.PermissionsSegment,
                UrlSegmentsTestConstants.PermissionsForResourcesSegment)
            .AbsoluteUri;
        var token = TestContext.CurrentContext.Random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        using var responseStream = File.OpenRead(Path.Combine("Permissions", "GetForResources-success.json"));
        using var responseContent = new StreamContent(responseStream);

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
            .Permissions()
            .GetForResources()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle();
    }
}
