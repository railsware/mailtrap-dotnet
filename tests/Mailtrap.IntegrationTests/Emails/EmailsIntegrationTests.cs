// -----------------------------------------------------------------------
// <copyright file="EmailsIntegrationTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.Emails;


[TestFixture]
internal sealed class EmailsIntegrationTests
{
    private const string Feature = "Emails";

    private const string LastIdQueryParameter = "last_id";
    private const string PageQueryParameter = "page";
    private const string SearchFilterQueryParameter = "search";

    private const string ForwardSegment = "forward";
    private const string HeadersSegment = "mail_headers";
    private const string SpamReportSegment = "spam_report";
    private const string HtmlAnalysisReportSegment = "analyze";
    private const string TextBodySegment = "body.txt";
    private const string HtmlBodySegment = "body.html";
    private const string EmlBodySegment = "body.eml";
    private const string RawBodySegment = "body.raw";
    private const string HtmlSourceSegment = "body.htmlsource";


    private readonly long _accountId;
    private readonly long _inboxId;
    private readonly Uri _resourceUri;
    private readonly MailtrapClientOptions _clientConfig;
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    public EmailsIntegrationTests()
    {
        var random = TestContext.CurrentContext.Random;

        _accountId = random.NextLong();
        _inboxId = random.NextLong();
        _resourceUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(_accountId)
            .Append(UrlSegmentsTestConstants.InboxesSegment)
            .Append(_inboxId)
            .Append(UrlSegmentsTestConstants.EmailsSegment);

        var token = random.GetString();
        _clientConfig = new MailtrapClientOptions(token);
        _jsonSerializerOptions = _clientConfig.ToJsonSerializerOptions();
    }


    [Test]
    public async Task Fetch_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var requestUri = _resourceUri.AbsoluteUri;

        using var responseContent = await Feature.LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithExactQueryString("")
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Messages()
            .Fetch()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle()
        .Which.Should()
            .Match<EmailMessage>(m => m.Id == 42);
    }

    [Test]
    public async Task Fetch_WithFilter1_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var requestUri = _resourceUri.AbsoluteUri;

        var random = TestContext.CurrentContext.Random;
        var lastId = random.NextLong();
        var page = random.Next();
        var search = random.GetString();

        var filter = new EmailMessageFilter
        {
            LastId = lastId,
            Page = page,
            SearchFilter = search
        };

        using var responseContent = await Feature.LoadTestJsonToStringContent(fileName: "Fetch_Success");

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithQueryString(LastIdQueryParameter, lastId.ToString(CultureInfo.InvariantCulture))
            .WithQueryString(PageQueryParameter, page.ToString(CultureInfo.InvariantCulture))
            .WithQueryString(SearchFilterQueryParameter, search)
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Messages()
            .Fetch(filter)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle()
        .Which.Should()
            .Match<EmailMessage>(m => m.Id == 42);
    }

    [Test]
    public async Task Fetch_WithFilter2_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var requestUri = _resourceUri.AbsoluteUri;

        var random = TestContext.CurrentContext.Random;
        var lastId = random.NextLong();
        var page = random.Next();

        var filter = new EmailMessageFilter
        {
            LastId = lastId,
            Page = page,
            SearchFilter = string.Empty
        };

        using var responseContent = await Feature.LoadTestJsonToStringContent(fileName: "Fetch_Success");

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithQueryString(LastIdQueryParameter, lastId.ToString(CultureInfo.InvariantCulture))
            .WithQueryString(PageQueryParameter, page.ToString(CultureInfo.InvariantCulture))
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Messages()
            .Fetch(filter)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle()
        .Which.Should()
            .Match<EmailMessage>(m => m.Id == 42);
    }

    [Test]
    public async Task Fetch_WithFilter3_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var requestUri = _resourceUri.AbsoluteUri;

        var random = TestContext.CurrentContext.Random;
        var lastId = random.NextLong();
        var page = random.Next();

        var filter = new EmailMessageFilter
        {
            LastId = lastId,
            Page = page
        };

        using var responseContent = await Feature.LoadTestJsonToStringContent(fileName: "Fetch_Success");

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithQueryString(LastIdQueryParameter, lastId.ToString(CultureInfo.InvariantCulture))
            .WithQueryString(PageQueryParameter, page.ToString(CultureInfo.InvariantCulture))
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Messages()
            .Fetch(filter)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle()
        .Which.Should()
            .Match<EmailMessage>(m => m.Id == 42);
    }


    [Test]
    public async Task GetDetails_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var messageId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri.Append(messageId).AbsoluteUri;

        using var responseContent = await Feature.LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetDetails()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }

    [Test]
    public async Task Update_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethodEx.Patch;

        var messageId = random.NextLong();
        var requestUri = _resourceUri.Append(messageId).AbsoluteUri;

        var request = new UpdateEmailMessageRequest(false);

        using var responseContent = await Feature.LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request.ToDto(), _jsonSerializerOptions)
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .Update(request)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }

    [Test]
    public async Task Delete_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Delete;
        var messageId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri.Append(messageId).AbsoluteUri;

        using var responseContent = await Feature.LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .Delete()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }

    [Test]
    public async Task Forward_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Post;

        var messageId = random.NextLong();
        var requestUri = _resourceUri
            .Append(messageId)
            .Append(ForwardSegment)
            .AbsoluteUri;

        var request = new ForwardEmailMessageRequest("john.doe@domain.com");

        using var responseContent = await Feature.LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .Forward(request)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }


    [Test]
    public async Task GetHeaders_Success()
    {
        Task<EmailMessageHeaders> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetHeaders();

        await GetJson_Success(HeadersSegment, Act).ConfigureAwait(false);
    }

    [Test]
    public async Task GetSpamReport_Success()
    {
        Task<EmailMessageSpamReport> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetSpamReport();

        await GetJson_Success(SpamReportSegment, Act).ConfigureAwait(false);
    }

    [Test]
    public async Task GetHtmlAnalysisReport_Success()
    {
        Task<EmailMessageHtmlReport> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetHtmlAnalysisReport();

        await GetJson_Success(HtmlAnalysisReportSegment, Act).ConfigureAwait(false);
    }


    [Test]
    public async Task GetTextBody_Success()
    {
        Task<string> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetTextBody();

        string[] headers =
        [
            MediaTypeNames.Text.Plain,
            MimeTypes.Application.Json
        ];
        await GetText_Success(TextBodySegment, Act, headers).ConfigureAwait(false);
    }

    [Test]
    public async Task GetHtmlBody_Success()
    {
        Task<string> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetHtmlBody();

        string[] headers =
        [
            MediaTypeNames.Text.Html,
            MimeTypes.Application.Json
        ];
        await GetText_Success(HtmlBodySegment, Act, headers).ConfigureAwait(false);
    }

    [Test]
    public async Task GetHtmlSource_Success()
    {
        Task<string> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .GetHtmlSource();

        string[] headers =
        [
            MediaTypeNames.Text.Html,
            MediaTypeNames.Text.Plain,
            MimeTypes.Application.Json
        ];
        await GetText_Success(HtmlSourceSegment, Act, headers).ConfigureAwait(false);
    }

    [Test]
    public async Task AsRaw_Success()
    {
        Task<string> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .AsRaw();

        string[] headers =
        [
            MediaTypeNames.Text.Plain,
            MimeTypes.Application.Json
        ];
        await GetText_Success(RawBodySegment, Act, headers).ConfigureAwait(false);
    }

    [Test]
    public async Task AsEml_Success()
    {
        Task<string> Act(IMailtrapClient client, long messageId) => client
            .Account(_accountId)
            .Inbox(_inboxId)
            .Message(messageId)
            .AsEml();

        string[] headers =
        [
            MimeTypes.Message.Eml,
            MediaTypeNames.Text.Plain,
            MimeTypes.Application.Json
        ];
        await GetText_Success(EmlBodySegment, Act, headers).ConfigureAwait(false);
    }


    private async Task GetJson_Success<TResult>(
        string urlSegment,
        Func<IMailtrapClient, long, Task<TResult>> act)
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var messageId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri
            .Append(messageId)
            .Append(urlSegment)
            .AbsoluteUri;

        using var responseContent = await Feature.LoadTestJsonToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await act(client, messageId).ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }

    private async Task GetText_Success(
        string urlSegment,
        Func<IMailtrapClient, long, Task<string>> act,
        params string[] acceptHeaders)
    {
        // Arrange
        var httpMethod = HttpMethod.Get;
        var messageId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri
            .Append(messageId)
            .Append(urlSegment)
            .AbsoluteUri;

        using var responseContent = await Feature.LoadTestJsonToStringContent(filexExt: "txt");

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders(acceptHeaders.Select(v => new KeyValuePair<string, string>("Accept", v)))
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await act(client, messageId).ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }
}
