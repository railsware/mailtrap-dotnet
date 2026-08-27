namespace Mailtrap.TrackingOptOuts;


/// <summary>
/// Represents tracking opt-out resource.
/// </summary>
public interface ITrackingOptOutResource : IRestResource
{
    /// <summary>
    /// Removes the email address represented by this resource instance from the tracking
    /// opt-out list, so open and click tracking can apply again.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Deleted tracking opt-out.
    /// </returns>
    public Task<TrackingOptOut> Delete(CancellationToken cancellationToken = default);
}
