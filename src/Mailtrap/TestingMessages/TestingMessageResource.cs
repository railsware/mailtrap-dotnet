// -----------------------------------------------------------------------
// <copyright file="TestingMessageResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages;


internal sealed class TestingMessageResource : RestResource, ITestingMessageResource
{
    private const string AttachmentsSegment = "attachments";

    private const string ForwardSegment = "forward";
    private const string SpamReportSegment = "spam_report";
    private const string HtmlAnalysisReportSegment = "analyze";
    private const string HeadersSegment = "mail_headers";
    private const string TextBodySegment = "body.txt";
    private const string HtmlBodySegment = "body.html";
    private const string EmlBodySegment = "body.eml";
    private const string RawBodySegment = "body.raw";
    private const string HtmlSourceSegment = "body.htmlsource";


    public TestingMessageResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public IAttachmentCollectionResource Attachments()
        => new AttachmentCollectionResource(RestResourceCommandFactory, ResourceUri.Append(AttachmentsSegment));

    public IAttachmentResource Attachment(long attachmentId)
        => new AttachmentResource(RestResourceCommandFactory, ResourceUri.Append(AttachmentsSegment).Append(attachmentId));


    public async Task<TestingMessage> GetDetails(CancellationToken cancellationToken = default)
        => await Get<TestingMessage>(cancellationToken).ConfigureAwait(false);

    public async Task<TestingMessage> Update(UpdateTestingMessageRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateTestingMessageRequestDto, TestingMessage>(request.ToDto(), cancellationToken).ConfigureAwait(false);

    public async Task<TestingMessage> Delete(CancellationToken cancellationToken = default)
        => await Delete<TestingMessage>(cancellationToken).ConfigureAwait(false);


    public async Task<ForwardTestingMessageResponse> Forward(ForwardTestingMessageRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var uri = ResourceUri.Append(ForwardSegment);

        var result = await RestResourceCommandFactory
            .CreatePost<ForwardTestingMessageRequest, ForwardTestingMessageResponse>(uri, request)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    public async Task<TestingMessageHeaders> GetHeaders(CancellationToken cancellationToken = default)
        => await Get<TestingMessageHeaders>(HeadersSegment, cancellationToken).ConfigureAwait(false);

    public async Task<TestingMessageSpamReport> GetSpamReport(CancellationToken cancellationToken = default)
        => await Get<TestingMessageSpamReport>(SpamReportSegment, cancellationToken).ConfigureAwait(false);

    public async Task<TestingMessageHtmlReport> GetHtmlAnalysisReport(CancellationToken cancellationToken = default)
        => await Get<TestingMessageHtmlReport>(HtmlAnalysisReportSegment, cancellationToken).ConfigureAwait(false);

    public async Task<string> GetTextBody(CancellationToken cancellationToken = default)
        => await GetContent(TextBodySegment, cancellationToken, MediaTypeNames.Text.Plain).ConfigureAwait(false);

    public async Task<string> GetHtmlBody(CancellationToken cancellationToken = default)
        => await GetContent(HtmlBodySegment, cancellationToken, MediaTypeNames.Text.Html).ConfigureAwait(false);

    public async Task<string> AsRaw(CancellationToken cancellationToken = default)
        => await GetContent(RawBodySegment, cancellationToken, MediaTypeNames.Text.Plain).ConfigureAwait(false);

    public async Task<string> GetHtmlSource(CancellationToken cancellationToken = default)
        => await GetContent(HtmlSourceSegment, cancellationToken, MediaTypeNames.Text.Html, MediaTypeNames.Text.Plain).ConfigureAwait(false);

    public async Task<string> AsEml(CancellationToken cancellationToken = default)
        => await GetContent(EmlBodySegment, cancellationToken, MimeTypes.Message.Eml, MediaTypeNames.Text.Plain).ConfigureAwait(false);


    private async Task<string> GetContent(
        string segment,
        CancellationToken cancellationToken,
        params string[] additionalAcceptContentTypes)
    {
        var uri = ResourceUri.Append(segment);

        var result = await RestResourceCommandFactory
            .CreatePlainText(uri, additionalAcceptContentTypes)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
