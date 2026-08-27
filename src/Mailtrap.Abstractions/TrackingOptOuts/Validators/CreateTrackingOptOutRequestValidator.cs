namespace Mailtrap.TrackingOptOuts.Validators;


/// <summary>
/// Validator for <see cref="CreateTrackingOptOutRequest"/>.<br/>
/// Ensures the email address and sending domain identifier are provided.
/// </summary>
public sealed class CreateTrackingOptOutRequestValidator : AbstractValidator<CreateTrackingOptOutRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static CreateTrackingOptOutRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public CreateTrackingOptOutRequestValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("'Email' must not be empty.");

        RuleFor(r => r.DomainId)
            .GreaterThan(0)
            .WithMessage("'DomainId' must be a positive sending domain ID.");
    }
}
