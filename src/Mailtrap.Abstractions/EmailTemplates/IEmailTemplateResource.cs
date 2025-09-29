namespace Mailtrap.EmailTemplates;

/// <summary>
/// Represents Email Template resource.
/// </summary>
public interface IEmailTemplateResource : IRestResource
{
    /// <summary>
    /// Gets details of the email template, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested email template details.
    /// </returns>
    public Task<EmailTemplate> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the email template, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Email template details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated email template details.
    /// </returns>
    public Task<EmailTemplate> Update(UpdateEmailTemplateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an email template, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Nothing is returned upon successful deletion.
    /// </returns>
    ///
    /// <remarks>
    /// <para>
    /// After deletion of the email template, represented by the current resource instance, it will no longer be available.<br />
    /// Thus any further operations on it will result in an error.
    /// </para>
    /// </remarks>
    public Task Delete(CancellationToken cancellationToken = default);
}
