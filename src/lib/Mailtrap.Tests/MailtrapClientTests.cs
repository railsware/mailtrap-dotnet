// -----------------------------------------------------------------------
// <copyright file="MailtrapClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


//namespace Mailtrap.Tests.Unit.Providers;


//[TestFixture]
//internal sealed class MailtrapClientTests
//{
//    [Test]
//    public void ShouldThrowWhenEmptyBaseUrlProvidedToConstructor()
//    {
//        var act = () => new MailtrapClient(string.Empty, "token");

//        act.Should().Throw<ArgumentException>();
//    }

//    [Test]
//    public void ShouldThrowWhenEmptyTokenProvidedToConstructor()
//    {
//        var act = () => new MailtrapClient("https://api.mailtrap.io/", string.Empty);

//        act.Should().Throw<ArgumentException>();
//    }

//    [Test]
//    public async Task SendShouldDoHttpPost()
//    {
//        var testBaseUrl = new Uri("https://localhost/");

//        var testUrl = new Uri(testBaseUrl, "api/send");

//        var apiHostProviderMock = new Mock<IApiBaseUrlProvider>();
//        apiHostProviderMock
//            .Setup(p => p.SendEmailHost)
//            .Returns(testBaseUrl);

//        var mockHttp = new MockHttpMessageHandler();

//        var messageId = new MessageId("1");
//        var response = new EmailSendApiResponse(true, [messageId]);

//        var content = JsonContent.Create(response);

//        mockHttp
//            .Expect(HttpMethod.Post, testUrl.AbsoluteUri)
//            .Respond(HttpStatusCode.OK, content);

//        var httpClientProviderMock = new Mock<IHttpClientProvider>();
//        httpClientProviderMock
//            .Setup(p => p.GetClientAsync(It.IsAny<CancellationToken>()))
//            .ReturnsAsync(mockHttp.ToHttpClient());

//        var client = new MailtrapClient(apiHostProviderMock.Object, httpClientProviderMock.Object, DefaultSerializationOptionsProvider.Instance);

//        var request = EmailSendApiRequestBuilder
//            .Create()
//            .WithSender("john.doe@demomailtrap.com", "John Doe")
//            .WithSubject("Invitation to Earth")
//            .WithRecipient("zhaparoff@gmail.com")
//            .WithTextBody("Dear Anton, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");

//        var result = await client.SendAsync(request);

//        mockHttp.VerifyNoOutstandingExpectation();

//        result.Should().NotBeNull();
//        result!.Success.Should().BeTrue();
//        result!.MessageIds.Should().ContainSingle(m => m == messageId);
//    }
//}
