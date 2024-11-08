// -----------------------------------------------------------------------
// <copyright file="AccountsIntegrationTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.Accounts;


[TestFixture]
internal sealed class AccountsIntegrationTests
{
    [Test]
    public async Task GetAll_Success()
    {
        // Arrange
        using var mockHttp = new MockHttpMessageHandler();
        var httpMethod = HttpMethod.Get;
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .AbsoluteUri;
        var token = TestContext.CurrentContext.Random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var account1 = new Account
        {
            Id = TestContext.CurrentContext.Random.NextLong(),
            Name = TestContext.CurrentContext.Random.GetString(50)
        };
        account1.AccessLevels.Add(Models.AccessLevel.Owner);

        var account2 = new Account
        {
            Id = TestContext.CurrentContext.Random.NextLong(),
            Name = TestContext.CurrentContext.Random.GetString(50)
        };
        account1.AccessLevels.Add(Models.AccessLevel.Admin);

        var response = new List<Account>([account1, account2]);
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
            .Accounts()
            .GetAll()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);
    }
}
