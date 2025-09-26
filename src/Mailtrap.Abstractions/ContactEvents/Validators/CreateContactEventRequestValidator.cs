namespace Mailtrap.ContactEvents.Validators;


/// <summary>
/// Validator for <see cref="CreateContactEventRequest"/> requests.<br />
/// Ensures contact event's Name is not empty and length is within the allowed range.<br/>
/// Ensures all parameter keys (if any) are non-empty, and within the allowed length.
/// </summary>
public sealed class CreateContactEventRequestValidator : AbstractValidator<CreateContactEventRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static CreateContactEventRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public CreateContactEventRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().MaximumLength(255);

        When(r => r.Params != null && r.Params.Count > 0, () =>
        {
            RuleForEach(r => r.Params.Keys)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(255);
        });
    }
}
