// -----------------------------------------------------------------------
// <copyright file="AccountAccessesIntegrationTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.AccountAccesses;


[TestFixture]
internal sealed class AccountAccessesIntegrationTests
{
    private const string ProjectsQueryParameter = "project_ids";
    private const string InboxesQueryParameter = "inbox_ids";
    private const string DomainsQueryParameter = "domain_ids";
    private const string UpdatePermissionsSegment = "permissions/bulk";


    [Test]
    public async Task Fetch_Success_WithoutFilter()
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
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .AbsoluteUri;
        var token = TestContext.CurrentContext.Random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var response = new List<AccountAccess>();
        using var responseContent = JsonContent.Create(response);

        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithExactQueryString("")
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
            .Accesses()
            .Fetch()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);
    }

    [Test]
    public async Task Fetch_Success_WithFilter()
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
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .AbsoluteUri;
        var token = TestContext.CurrentContext.Random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var projectId = TestContext.CurrentContext.Random.NextLong();
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var domainId = TestContext.CurrentContext.Random.NextLong();

        var filter = new AccountAccessFilter();
        filter.ProjectIds.Add(projectId);
        filter.InboxIds.Add(inboxId);
        filter.DomainIds.Add(domainId);

        var response = new List<AccountAccess>();
        using var responseContent = JsonContent.Create(response);

        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithQueryString(ProjectsQueryParameter, $"[{projectId}]")
            .WithQueryString(InboxesQueryParameter, $"[{inboxId}]")
            .WithQueryString(DomainsQueryParameter, $"[{domainId}]")
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
            .Accesses()
            .Fetch(filter)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);
    }


    [Test]
    public async Task UpdatePermissions_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;
        using var mockHttp = new MockHttpMessageHandler();
        var httpMethod = HttpMethod.Put;
        var accountId = random.NextLong();
        var accessId = random.NextLong();
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .Append(accessId)
            .Append(UpdatePermissionsSegment)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var permissions = new UpdatePermissionsRequestItem(
            random.NextLong(), AccountResourceType.Account, Models.AccessLevel.Admin);
        var request = new UpdatePermissionsRequest(permissions);

        var response = new UpdatedPermissions
        {
            Message = TestContext.CurrentContext.Random.GetString(200)
        };
        using var responseContent = JsonContent.Create(response);

        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request, clientConfig.ToJsonSerializerOptions())
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
            .Access(accessId)
            .UpdatePermissions(request)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);
    }

    [Test]
    public async Task Delete_Success()
    {
        // Arrange
        using var mockHttp = new MockHttpMessageHandler();
        var httpMethod = HttpMethod.Delete;
        var accountId = TestContext.CurrentContext.Random.NextLong();
        var accessId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .Append(accessId)
            .AbsoluteUri;
        var token = TestContext.CurrentContext.Random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var response = new DeletedAccountAccess
        {
            Id = accessId
        };
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
            .Access(accessId)
            .Delete()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);
    }
}
