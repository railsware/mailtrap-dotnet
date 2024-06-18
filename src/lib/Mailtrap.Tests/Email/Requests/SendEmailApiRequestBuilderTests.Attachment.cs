// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Attachment.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Attachment
{
    private string Content { get; } = "Attachment Content";
    private string FileName { get; } = "filename.ext";
    private Attachment _attachment1 { get; } = new("Content 1", "file1.txt");
    private Attachment _attachment2 { get; } = new("Content 2", "file2.txt", mimeType: MediaTypeNames.Text.Plain, contentId: "ID2");



    #region WithAttachments

    [Test]
    public void WithAttachments_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithAttachments<RegularSendEmailApiRequest>(null!, _attachment1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachments_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachments(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachments_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachments(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void WithAttachments_ShouldAddAttachmentsToCollection()
    {
        WithAttachments_CreateAndValidate(_attachment1, _attachment2);
    }

    [Test]
    public void WithAttachments_ShouldAddAttachmentsToCollection_WhenCalledMultipleTimes()
    {
        var attachment3 = new Attachment("Content 3", "file3.png", DispositionType.Inline, MediaTypeNames.Image.Png);
        var attachment4 = new Attachment("Content 4", "file4.pdf", mimeType: MediaTypeNames.Application.Pdf, contentId: "ID 4");

        var request = WithAttachments_CreateAndValidate(_attachment1, _attachment2);

        request.WithAttachments(attachment3, attachment4);

        request.Attachments.Should()
            .HaveCount(4).And
            .ContainInOrder(_attachment1, _attachment2, attachment3, attachment4);
    }

    [Test]
    public void WithAttachments_ShouldNotAddAttachmentsToCollection_WhenParamsIsEmpty()
    {
        var request = WithAttachments_CreateAndValidate(_attachment1, _attachment2);

        request.WithAttachments([]);

        request.Attachments.Should()
            .HaveCount(2).And
            .ContainInOrder(_attachment1, _attachment2);
    }


    private static RegularSendEmailApiRequest WithAttachments_CreateAndValidate(params Attachment[] attachments)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithAttachments(attachments);

        request.Attachments.Should()
            .HaveCount(2).And
            .ContainInOrder(attachments);

        return request;
    }

    #endregion



    #region WithAttachment(attachment)

    [Test]
    public void WithAttachment_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithAttachment<RegularSendEmailApiRequest>(null!, _attachment1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachment_ShouldThrowArgumentNullException_WhenAttachmentIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachment_ShouldAddAttachmentToCollection()
    {
        WithAttachment_CreateAndValidate(_attachment1);
    }

    [Test]
    public void WithAttachment_ShouldAddAttachmentToCollection_WhenCalledMultipleTimes()
    {
        var request = WithAttachment_CreateAndValidate(_attachment1);

        request.WithAttachment(_attachment2);

        request.Attachments.Should()
            .HaveCount(2).And
            .ContainInOrder(_attachment1, _attachment2);
    }


    private static RegularSendEmailApiRequest WithAttachment_CreateAndValidate(Attachment attachment)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithAttachment(attachment);

        request.Attachments.Should()
            .ContainSingle().And
            .Contain(attachment);

        return request;
    }

    #endregion



    #region WithAttachment(content, fileName, disposition, mimeType, contentId)

    [Test]
    public void WithAttachment_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment<RegularSendEmailApiRequest>(null!, Content, FileName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachment_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, null!, FileName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachment_ShouldThrowArgumentNullException_WhenContentIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, string.Empty, FileName);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachment_ShouldThrowArgumentNullException_WhenFileNameIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, Content, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithAttachment_ShouldNotThrowException_WhenFileNameIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, Content, string.Empty);

        act.Should().NotThrow();
    }

    [Test, Combinatorial]
    public void WithAttachment_ShouldNotThrowException_WhenAllOptionalParamsAreNullOrEmpty(
        [Values(null, "")] string? mimeType,
        [Values(null, "")] string? contentId)
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, Content, FileName, null, mimeType, contentId);

        act.Should().NotThrow();
    }

    [Test, Combinatorial]
    public void WithAttachment_ShouldNotThrowException_WhenDispositionIsSetAndOtherOptionalParamsAreNullOrEmpty(
        [Values(null, "")] string? mimeType,
        [Values(null, "")] string? contentId)
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithAttachment(request, Content, FileName, DispositionType.Inline, mimeType, contentId);

        act.Should().NotThrow();
    }

    [Test]
    public void WithAttachment_ShouldAddAttachmentToCollectionAndInitPropertiesCorrectly_WhenOnlyRequiredParametersSpecified()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithAttachment(Content, FileName);

        request.Attachments.Should().ContainSingle();

        var added = request.Attachments.First();
        added.Content.Should().Be(Content);
        added.FileName.Should().Be(FileName);
        added.Disposition.Should().Be(DispositionType.Attachment);
        added.MimeType.Should().BeNull();
        added.ContentId.Should().BeNull();
    }

    [Test]
    public void WithAttachment_ShouldAddAttachmentToCollectionAndInitPropertiesCorrectly_WhenAllParametersSpecified()
    {
        var disposition = DispositionType.Inline;
        var mimeType = MediaTypeNames.Image.Png;
        var contentId = "<ID>";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithAttachment(Content, FileName, disposition, mimeType, contentId);

        request.Attachments.Should().ContainSingle();

        var added = request.Attachments.First();
        added.Content.Should().Be(Content);
        added.FileName.Should().Be(FileName);
        added.Disposition.Should().Be(disposition);
        added.MimeType.Should().Be(mimeType);
        added.ContentId.Should().Be(contentId);
    }

    #endregion
}
