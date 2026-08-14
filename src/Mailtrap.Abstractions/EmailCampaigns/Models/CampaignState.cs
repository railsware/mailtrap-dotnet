namespace Mailtrap.EmailCampaigns.Models;


/// <summary>
/// Current state of an email campaign in its lifecycle.
/// </summary>
public sealed record CampaignState : StringEnum<CampaignState>
{
    /// <summary>
    /// Gets the value representing the "draft" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "draft" campaign state.
    /// </value>
    public static readonly CampaignState Draft = Define("draft");

    /// <summary>
    /// Gets the value representing the "scheduled" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "scheduled" campaign state.
    /// </value>
    public static readonly CampaignState Scheduled = Define("scheduled");

    /// <summary>
    /// Gets the value representing the "started" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "started" campaign state.
    /// </value>
    public static readonly CampaignState Started = Define("started");

    /// <summary>
    /// Gets the value representing the "queued" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "queued" campaign state.
    /// </value>
    public static readonly CampaignState Queued = Define("queued");

    /// <summary>
    /// Gets the value representing the "paused" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "paused" campaign state.
    /// </value>
    public static readonly CampaignState Paused = Define("paused");

    /// <summary>
    /// Gets the value representing the "terminating" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "terminating" campaign state.
    /// </value>
    public static readonly CampaignState Terminating = Define("terminating");

    /// <summary>
    /// Gets the value representing the "under_review" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "under_review" campaign state.
    /// </value>
    public static readonly CampaignState UnderReview = Define("under_review");

    /// <summary>
    /// Gets the value representing the "finished" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "finished" campaign state.
    /// </value>
    public static readonly CampaignState Finished = Define("finished");

    /// <summary>
    /// Gets the value representing the "failed" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "failed" campaign state.
    /// </value>
    public static readonly CampaignState Failed = Define("failed");

    /// <summary>
    /// Gets the value representing the "failed_immediately" campaign state.
    /// </summary>
    ///
    /// <value>
    /// Represents the "failed_immediately" campaign state.
    /// </value>
    public static readonly CampaignState FailedImmediately = Define("failed_immediately");
}
