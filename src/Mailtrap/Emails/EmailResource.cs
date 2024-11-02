// -----------------------------------------------------------------------
// <copyright file="EmailResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails;


internal sealed class EmailResource : RestResource, IEmailResource
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


    public EmailResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public IAttachmentCollectionResource Attachments()
        => new AttachmentCollectionResource(RestResourceCommandFactory, ResourceUri.Append(AttachmentsSegment));

    public IAttachmentResource Attachment(long attachmentId)
        => new AttachmentResource(RestResourceCommandFactory, ResourceUri.Append(AttachmentsSegment).Append(attachmentId));


    public async Task<EmailMessage> GetDetails(CancellationToken cancellationToken = default)
        => await Get<EmailMessage>(cancellationToken).ConfigureAwait(false);

    public async Task<EmailMessage> Update(UpdateEmailMessageRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateEmailMessageRequestDto, EmailMessage>(request.ToDto(), cancellationToken).ConfigureAwait(false);

    public async Task<EmailMessage> Delete(CancellationToken cancellationToken = default)
        => await Delete<EmailMessage>(cancellationToken).ConfigureAwait(false);


    public async Task<ForwardedEmailMessage> Forward(ForwardEmailMessageRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var uri = ResourceUri.Append(ForwardSegment);

        EnsureNotDeleted(HttpMethod.Post, uri);

        var result = await RestResourceCommandFactory
            .CreatePost<ForwardEmailMessageRequest, ForwardedEmailMessage>(uri, request)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    public async Task<EmailMessageHeaders> GetHeaders(CancellationToken cancellationToken = default)
        => await Get<EmailMessageHeaders>(HeadersSegment, cancellationToken).ConfigureAwait(false);

    public async Task<EmailMessageSpamReport> GetSpamReport(CancellationToken cancellationToken = default)
        => await Get<EmailMessageSpamReport>(SpamReportSegment, cancellationToken).ConfigureAwait(false);

    public async Task<EmailMessageHtmlReport> GetHtmlAnalysisReport(CancellationToken cancellationToken = default)
        => await Get<EmailMessageHtmlReport>(HtmlAnalysisReportSegment, cancellationToken).ConfigureAwait(false);

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

        EnsureNotDeleted(HttpMethod.Get, uri);

        var result = await RestResourceCommandFactory
            .CreatePlainText(uri, additionalAcceptContentTypes)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
