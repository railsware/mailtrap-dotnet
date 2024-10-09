// -----------------------------------------------------------------------
// <copyright file="IInboxResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes;


/// <summary>
/// Represents inbox resource.
/// </summary>
public interface IInboxResource
{
    /// <summary>
    /// Gets message collection resource for the inbox, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Message collection resource for the inbox, represented by this resource instance.
    /// </returns>
    public IMessageCollectionResource Messages();

    /// <summary>
    /// Gets resource for specific message, identified by <paramref name="messageId"/>,
    /// in the inbox, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="messageId">
    /// ID of message to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the message with specified ID.
    /// </returns>
    public IMessageResource Message(long messageId);


    /// <summary>
    /// Gets details of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing requested inbox details.
    /// </returns>
    public Task<Response<Inbox>> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the inbox, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Inbox details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing updated inbox details.
    /// </returns>
    public Task<Response<Inbox>> Update(UpdateInboxRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the inbox, represented by the current resource instance, with all its emails.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing deleted inbox details.
    /// </returns>
    ///
    /// <remarks>
    /// <para>
    /// All emails in the inbox will be deleted as well.
    /// </para>
    /// <para>
    /// After deletion of the inbox, represented by the current resource instance, it will be no longer available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task<Response<Inbox>> Delete(CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete all messages (emails) from the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Response containing affected inbox details.
    /// </returns>
    public Task<Response<Inbox>> Clean(CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks all messages (emails) in the inbox, represented by the current resource instance, as read.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Response<Inbox>> MarkAsRead(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets SMTP credentials of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Response<Inbox>> ResetCredentials(CancellationToken cancellationToken = default);

    /// <summary>
    /// Turns the email address of the inbox, represented by the current resource instance, ON or OFF.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Response<Inbox>> ToggleEmailAddress(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets username of email address of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Response<Inbox>> ResetEmailAddress(CancellationToken cancellationToken = default);
}
