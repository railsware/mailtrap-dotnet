namespace Mailtrap.EmailCampaigns.Models;


/// <summary>
/// Represents an optional aggregation window for email campaign statistics.<br/>
/// By default, statistics are aggregated over the whole period since the campaign was last started.
/// </summary>
public sealed record EmailCampaignStatsFilter
{
    /// <summary>
    /// Gets or sets the start of the aggregation window (inclusive), in <c>YYYY-MM-DD</c> format.
    /// </summary>
    ///
    /// <value>
    /// Window start date, or <see langword="null"/> to default to the day the campaign was last started.
    /// </value>
    ///
    /// <remarks>
    /// Serialized to the <c>start_date</c> query parameter.
    /// </remarks>
    public string? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end of the aggregation window (inclusive), in <c>YYYY-MM-DD</c> format.
    /// </summary>
    ///
    /// <value>
    /// Window end date, or <see langword="null"/> to default to the current date.
    /// </value>
    ///
    /// <remarks>
    /// Serialized to the <c>end_date</c> query parameter.
    /// </remarks>
    public string? EndDate { get; set; }
}
