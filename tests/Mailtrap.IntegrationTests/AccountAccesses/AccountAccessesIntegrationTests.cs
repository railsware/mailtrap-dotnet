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
    public async Task Fetch_WithoutFilter_Success()
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
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        using var responseContent = await "AccountAccesses".LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
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
            .ContainSingle()
        .Which.Should()
            .Match<AccountAccess>(a => a.Id == 42);
    }

    [Test]
    public async Task Fetch_WithFilter_Success()
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
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var projectId = random.NextLong();
        var inboxId = random.NextLong();
        var domainId = random.NextLong();

        var filter = new AccountAccessFilter();
        filter.ProjectIds.Add(projectId);
        filter.InboxIds.Add(inboxId);
        filter.DomainIds.Add(domainId);

        using var responseContent = await "AccountAccesses".LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
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
            .ContainSingle()
        .Which.Should()
            .Match<AccountAccess>(a => a.Id == 42);
    }


    [Test]
    public async Task UpdatePermissions_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

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
            random.NextLong(), ResourceType.Account, AccessLevel.Admin);
        var request = new UpdatePermissionsRequest(permissions);

        using var responseContent = await "AccountAccesses".LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
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

        result.Should().NotBeNull();
    }


    [Test]
    public async Task Delete_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Delete;
        var accountId = random.NextLong();
        var accessId = 2981;
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .Append(accessId)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        using var responseContent = await "AccountAccesses".LoadTestJsonToStringContent();

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
            .Access(accessId)
            .Delete()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .Match<DeleteAccountAccessResponse>(a => a.Id == accessId);
    }

    [Test]
    public async Task Delete_NotFound()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Delete;
        var accountId = random.NextLong();
        var accessId = 2981;
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(UrlSegmentsTestConstants.AccountAccessesSegment)
            .Append(accessId)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        using var responseContent = await "AccountAccesses".LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.NotFound, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();

        var act = () => client
            .Account(accountId)
            .Access(accessId)
            .Delete();


        // Assert
        await act.Should()
            .ThrowAsync<HttpRequestFailedException>()
            .WithMessage("*'Not Found'*");

        mockHttp.VerifyNoOutstandingExpectation();
    }
}
