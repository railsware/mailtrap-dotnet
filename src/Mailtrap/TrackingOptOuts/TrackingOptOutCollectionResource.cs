namespace Mailtrap.TrackingOptOuts;


internal sealed class TrackingOptOutCollectionResource : RestResource, ITrackingOptOutCollectionResource
{
    private const string EmailQueryParameter = "email";
    private const string StartTimeQueryParameter = "start_time";
    private const string EndTimeQueryParameter = "end_time";
    private const string LastIdQueryParameter = "last_id";


    public TrackingOptOutCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<TrackingOptOutList> Fetch(TrackingOptOutFilter? filter = null, CancellationToken cancellationToken = default)
        => await RestResourceCommandFactory
            .CreateGet<TrackingOptOutList>(CreateFetchUri(filter))
            .Execute(cancellationToken)
            .ConfigureAwait(false);

    public async Task<TrackingOptOut> Create(CreateTrackingOptOutRequest request, CancellationToken cancellationToken = default)
    {
        var response = await Create<CreateTrackingOptOutRequest, TrackingOptOutResponseDto>(request, cancellationToken).ConfigureAwait(false);

        return response.TrackingOptOut;
    }


    private Uri CreateFetchUri(TrackingOptOutFilter? filter)
    {
        if (filter is null)
        {
            return ResourceUri;
        }

        var result = ResourceUri;

        if (!string.IsNullOrWhiteSpace(filter.Email))
        {
            result = result.AppendQueryParameter(EmailQueryParameter, filter.Email);
        }

        if (filter.StartTime is not null)
        {
            result = result.AppendQueryParameter(StartTimeQueryParameter, filter.StartTime.Value.ToString("O"));
        }

        if (filter.EndTime is not null)
        {
            result = result.AppendQueryParameter(EndTimeQueryParameter, filter.EndTime.Value.ToString("O"));
        }

        if (!string.IsNullOrWhiteSpace(filter.LastId))
        {
            result = result.AppendQueryParameter(LastIdQueryParameter, filter.LastId);
        }

        return result;
    }
}
