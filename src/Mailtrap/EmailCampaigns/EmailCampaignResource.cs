namespace Mailtrap.EmailCampaigns;


internal sealed class EmailCampaignResource : RestResource, IEmailCampaignResource
{
    private const string StartDateQueryParameter = "start_date";
    private const string EndDateQueryParameter = "end_date";


    public EmailCampaignResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<EmailCampaign> GetDetails(CancellationToken cancellationToken = default)
    {
        var response = await Get<EmailCampaignResponseDto>(cancellationToken).ConfigureAwait(false);

        return response.EmailCampaign;
    }

    public async Task<EmailCampaign> Update(UpdateEmailCampaignRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var response = await Update<UpdateEmailCampaignRequest, EmailCampaignResponseDto>(request, cancellationToken).ConfigureAwait(false);

        return response.EmailCampaign;
    }

    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);

    public async Task<EmailCampaign> Start(CancellationToken cancellationToken = default)
        => await ExecuteAction(UrlSegments.StartSegment, cancellationToken).ConfigureAwait(false);

    public async Task<EmailCampaign> Schedule(ScheduleEmailCampaignRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var uri = ResourceUri.Append(UrlSegments.ScheduleSegment);

        var response = await RestResourceCommandFactory
            .CreatePost<ScheduleEmailCampaignRequest, EmailCampaignResponseDto>(uri, request)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return response.EmailCampaign;
    }

    public async Task<EmailCampaign> Cancel(CancellationToken cancellationToken = default)
        => await ExecuteAction(UrlSegments.CancelSegment, cancellationToken).ConfigureAwait(false);

    public async Task<EmailCampaign> Terminate(CancellationToken cancellationToken = default)
        => await ExecuteAction(UrlSegments.TerminateSegment, cancellationToken).ConfigureAwait(false);

    public async Task<EmailCampaign> Reset(CancellationToken cancellationToken = default)
        => await ExecuteAction(UrlSegments.ResetSegment, cancellationToken).ConfigureAwait(false);

    public async Task<EmailCampaignStats> GetStats(EmailCampaignStatsFilter? filter = null, CancellationToken cancellationToken = default)
    {
        var uri = CreateStatsUri(filter);

        var response = await RestResourceCommandFactory
            .CreateGet<EmailCampaignStatsResponseDto>(uri)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return response.Stats;
    }


    private async Task<EmailCampaign> ExecuteAction(string segment, CancellationToken cancellationToken)
    {
        var uri = ResourceUri.Append(segment);

        var response = await RestResourceCommandFactory
            .CreatePost<EmailCampaignResponseDto>(uri)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return response.EmailCampaign;
    }

    private Uri CreateStatsUri(EmailCampaignStatsFilter? filter)
    {
        var uri = ResourceUri.Append(UrlSegments.StatsSegment);

        if (filter is null)
        {
            return uri;
        }

        if (!string.IsNullOrEmpty(filter.StartDate))
        {
            uri = uri.AppendQueryParameter(StartDateQueryParameter, filter.StartDate);
        }

        if (!string.IsNullOrEmpty(filter.EndDate))
        {
            uri = uri.AppendQueryParameter(EndDateQueryParameter, filter.EndDate);
        }

        return uri;
    }
}
