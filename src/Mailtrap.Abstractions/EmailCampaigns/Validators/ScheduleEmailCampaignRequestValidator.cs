namespace Mailtrap.EmailCampaigns.Validators;


/// <summary>
/// Validator for <see cref="ScheduleEmailCampaignRequest"/>.<br/>
/// Ensures the scheduled time is in the future and no more than 1 month ahead,
/// mirroring the API's own constraints.
/// </summary>
public sealed class ScheduleEmailCampaignRequestValidator : AbstractValidator<ScheduleEmailCampaignRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static ScheduleEmailCampaignRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public ScheduleEmailCampaignRequestValidator()
    {
        RuleFor(r => r.Datetime)
            .Must(d => d > DateTimeOffset.UtcNow)
            .WithMessage("'Datetime' must be in the future.")
            .Must(d => d <= DateTimeOffset.UtcNow.AddMonths(1))
            .WithMessage("'Datetime' must be no more than 1 month ahead.");
    }
}
