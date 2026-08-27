namespace Mailtrap.TrackingOptOuts;


internal sealed class TrackingOptOutResource : RestResource, ITrackingOptOutResource
{
    public TrackingOptOutResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<TrackingOptOut> Delete(CancellationToken cancellationToken = default)
        => await Delete<TrackingOptOut>(cancellationToken).ConfigureAwait(false);
}
