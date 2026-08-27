namespace Mailtrap.TrackingOptOuts;


/// <summary>
/// Represents tracking opt-outs collection resource.
/// </summary>
public interface ITrackingOptOutCollectionResource : IRestResource
{
    /// <summary>
    /// Lists email addresses that have opted out of open and click tracking.
    /// </summary>
    ///
    /// <param name="filter">
    /// Optional filter to apply when fetching tracking opt-outs.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Page of tracking opt-outs and the cursor for the next page.
    /// </returns>
    ///
    /// <remarks>
    /// The endpoint returns up to 1000 records per request. When the result carries a
    /// cursor, pass it as <see cref="TrackingOptOutFilter.LastId"/> to fetch the next page.
    /// </remarks>
    public Task<TrackingOptOutList> Fetch(TrackingOptOutFilter? filter = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds an email address to the tracking opt-out list for a sending domain.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing the email address and sending domain.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="Fetch(TrackingOptOutFilter, CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created tracking opt-out.
    /// </returns>
    public Task<TrackingOptOut> Create(CreateTrackingOptOutRequest request, CancellationToken cancellationToken = default);
}
