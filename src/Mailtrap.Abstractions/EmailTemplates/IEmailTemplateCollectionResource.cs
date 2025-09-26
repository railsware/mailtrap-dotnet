namespace Mailtrap.EmailTemplates;

/// <summary>
/// Represents the email templates collection resource.
/// </summary>
public interface IEmailTemplateCollectionResource : IRestResource
{
    /// <summary>
    /// Gets collection of email template details.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of email template details.
    /// </returns>
    public Task<IList<EmailTemplate>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new email template with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing email template details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created email template details.
    /// </returns>
    public Task<EmailTemplate> Create(CreateEmailTemplateRequest request, CancellationToken cancellationToken = default);
}
