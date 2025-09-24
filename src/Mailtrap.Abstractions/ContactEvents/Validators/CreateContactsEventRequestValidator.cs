namespace Mailtrap.ContactEvents.Validators;


/// <summary>
/// Validator for Create contacts event requests.<br />
/// Ensures contacts event's Name is not empty and length is within the allowed range.<br/>
/// Ensures all parameter keys (if any) are non-empty, and within the allowed length.
/// </summary>
public sealed class CreateContactsEventRequestValidator : AbstractValidator<CreateContactsEventRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static CreateContactsEventRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public CreateContactsEventRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().Length(1, 255);

        When(r => r.Params != null && r.Params.Count > 0, () =>
        {
            RuleForEach(r => r.Params.Keys)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(255);
        });
    }
}
