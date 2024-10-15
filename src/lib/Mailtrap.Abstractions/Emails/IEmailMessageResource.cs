// -----------------------------------------------------------------------
// <copyright file="IEmailMessageResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails;


/// <summary>
/// Represents message resource.
/// </summary>
public interface IEmailMessageResource
{
    /// <summary>
    /// Gets attachment collection resource for the message, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Attachment collection resource for the message, represented by this resource instance.
    /// </returns>
    public IAttachmentCollectionResource Attachments();

    /// <summary>
    /// Gets resource for specific attachment, identified by <paramref name="attachmentId"/>,
    /// for the message, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="attachmentId">
    /// ID of attachment to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the attachment with specified ID.
    /// </returns>
    public IAttachmentResource Attachment(long attachmentId);


    /// <summary>
    /// Gets details of the message, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing requested message details.
    /// </returns>
    public Task<Response<EmailMessage>> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the message, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Message details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing updated message details.
    /// </returns>
    public Task<Response<EmailMessage>> Update(UpdateEmailMessageRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the message, represented by the current resource instance, with all its attachments.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing deleted message details.
    /// </returns>
    ///
    /// <remarks>
    /// <para>
    /// All attachments, associated with the message, will be deleted as well.
    /// </para>
    /// <para>
    /// After deletion of the message, represented by the current resource instance, it will be no longer available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task<Response<EmailMessage>> Delete(CancellationToken cancellationToken = default);

    /// <summary>
    /// Forwards the message, represented by the current resource instance, to the email specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request with forwarding details.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing forwarding result details.
    /// </returns>
    ///
    /// <remarks>
    /// The email address for forwarding must be confirmed by the recipient in advance.
    /// </remarks>
    public Task<Response<ForwardedEmailMessage>> Forward(ForwardEmailMessageRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a brief spam report for the message, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message spam report details.
    /// </returns>
    public Task<Response<EmailMessageSpamReport>> GetSpamReport(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a brief HTML report for the message, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message HTML analysis details.
    /// </returns>
    public Task<Response<EmailMessageHtmlReport>> GetHtmlAnalysisReport(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a plain text body of the message (if exists), represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message plain text body.
    /// </returns>
    public Task<Response<EmailMessageTextBody>> GetTextBody(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets HTML body of the message (if exists), represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message HTML body.
    /// </returns>
    ///
    /// <remarks>
    /// Not applicable for plain text messages.
    /// </remarks>
    public Task<Response<EmailMessageHtmlBody>> GetHtmlBody(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets HTML source of the message, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message HTML source.
    /// </returns>
    public Task<Response<EmailMessageHtmlSource>> GetHtmlSource(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the message, represented by the current resource instance, in a raw format.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message in a raw format.
    /// </returns>
    public Task<Response<EmailMessageRaw>> AsRaw(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the message, represented by the current resource instance, in .eml format.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message in .eml format.
    /// </returns>
    public Task<Response<EmailMessageEml>> AsEml(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets headers of the message, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing message headers.
    /// </returns>
    public Task<Response<EmailMessageHeaders>> GetHeaders(CancellationToken cancellationToken = default);
}
