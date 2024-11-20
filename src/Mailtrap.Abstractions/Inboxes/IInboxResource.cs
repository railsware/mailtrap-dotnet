// -----------------------------------------------------------------------
// <copyright file="IInboxResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes;


/// <summary>
/// Represents inbox resource.
/// </summary>
public interface IInboxResource : IRestResource
{
    /// <summary>
    /// Gets details of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Requested inbox details.
    /// </returns>
    public Task<Inbox> GetDetails(CancellationToken cancellationToken = default);

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
    /// Updated inbox details.
    /// </returns>
    public Task<Inbox> Update(UpdateInboxRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the inbox, represented by the current resource instance, with all its emails.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Deleted inbox details.
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
    public Task<Inbox> Delete(CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete all messages (emails) from the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Affected inbox details.
    /// </returns>
    public Task<Inbox> Clean(CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks all messages (emails) in the inbox, represented by the current resource instance, as read.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Inbox> MarkAsRead(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets SMTP credentials of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Inbox> ResetCredentials(CancellationToken cancellationToken = default);

    /// <summary>
    /// Turns the email address of the inbox, represented by the current resource instance, ON or OFF.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Inbox> ToggleEmailAddress(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets username of email address of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="Clean(CancellationToken)" path="/returns"/>
    public Task<Inbox> ResetEmailAddress(CancellationToken cancellationToken = default);
}
