namespace Mailtrap.ContactFields.Validators;


/// <summary>
/// Validator for Update contacts field requests.<br />
/// Ensures at least one of Name or MergeTag is provided, and any provided values are non‑whitespace and 1–80 chars.
/// </summary>
public sealed class UpdateContactsFieldRequestValidator : AbstractValidator<UpdateContactsFieldRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static UpdateContactsFieldRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public UpdateContactsFieldRequestValidator()
    {
        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.Name) ||
                       !string.IsNullOrEmpty(x.MergeTag))
            .WithMessage(x => $"At least one of {nameof(x.Name)} or {nameof(x.MergeTag)} must be provided.");

        When(x => !string.IsNullOrEmpty(x.Name), () =>
        {
            RuleFor(r => r.Name).NotEmpty().Length(1, 80);
        });

        When(x => !string.IsNullOrEmpty(x.MergeTag), () =>
        {
            RuleFor(r => r.MergeTag).NotEmpty().Length(1, 80);
        });
    }
}
