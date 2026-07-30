namespace Mailtrap.EmailCampaigns;


/// <summary>
/// Represents a single email campaign resource.
/// </summary>
public interface IEmailCampaignResource : IRestResource
{
    /// <summary>
    /// Gets the details of the email campaign, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Email campaign details.
    /// </returns>
    public Task<EmailCampaign> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the email campaign, represented by this resource instance, with details specified
    /// by <paramref name="request"/>.<br/>
    /// Only <see cref="CampaignState.Draft"/> campaigns can be updated.
    /// Only the provided attributes are changed.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing email campaign details to update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated email campaign details.
    /// </returns>
    public Task<EmailCampaign> Update(UpdateEmailCampaignRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the email campaign, represented by this resource instance.<br/>
    /// The campaign must not be in a sending state.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Awaitable task, representing the operation.
    /// </returns>
    ///
    /// <remarks>
    /// On success the API returns HTTP 204 with no response body.
    /// After deletion, the resource represented by this instance should no longer be used.
    /// </remarks>
    public Task Delete(CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts sending the email campaign, represented by this resource instance, immediately.<br/>
    /// The campaign must be in the <see cref="CampaignState.Draft"/> state and pass full
    /// sending validation (design, audience, verified sending domain, billing).
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Email campaign details after the state transition.
    /// </returns>
    public Task<EmailCampaign> Start(CancellationToken cancellationToken = default);

    /// <summary>
    /// Schedules the email campaign, represented by this resource instance, to start sending
    /// at a future time.<br/>
    /// The campaign must be in the <see cref="CampaignState.Draft"/> state and pass full
    /// sending validation. After scheduling, the time is reported back in
    /// <see cref="EmailCampaignStateMetadata.ScheduledAt"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing the date and time to send the campaign at.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Email campaign details after the state transition.
    /// </returns>
    public Task<EmailCampaign> Schedule(ScheduleEmailCampaignRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the scheduled email campaign, represented by this resource instance, removing the
    /// pending send job and returning the campaign to the <see cref="CampaignState.Draft"/> state.<br/>
    /// The campaign must be in the <see cref="CampaignState.Scheduled"/> state.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Email campaign details after the state transition.
    /// </returns>
    public Task<EmailCampaign> Cancel(CancellationToken cancellationToken = default);

    /// <summary>
    /// Terminates the email campaign, represented by this resource instance, aborting the
    /// in-flight send.<br/>
    /// The campaign must be in a sending state (<see cref="CampaignState.Started"/>,
    /// <see cref="CampaignState.Queued"/>, or <see cref="CampaignState.Paused"/>).
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Email campaign details after the state transition.
    /// </returns>
    public Task<EmailCampaign> Terminate(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets the email campaign, represented by this resource instance, back to the
    /// <see cref="CampaignState.Draft"/> state.<br/>
    /// Allowed only from the <see cref="CampaignState.Scheduled"/> state.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Email campaign details after the state transition.
    /// </returns>
    public Task<EmailCampaign> Reset(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets aggregated performance statistics for the email campaign, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="filter">
    /// Optional aggregation window (<c>start_date</c>/<c>end_date</c>).
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Aggregated campaign statistics. All counts and rates are <c>0</c> when the campaign has not been started.
    /// </returns>
    public Task<EmailCampaignStats> GetStats(EmailCampaignStatsFilter? filter = null, CancellationToken cancellationToken = default);
}
