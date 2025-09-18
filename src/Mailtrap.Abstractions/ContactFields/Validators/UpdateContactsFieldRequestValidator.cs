namespace Mailtrap.ContactFields.Validators;


/// <summary>
/// Validator for Create/Update contacts field requests.<br />
/// Ensures contacts field's Name and Merge Tag is not empty and length is within the allowed range.
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
            .Must(x => !string.IsNullOrWhiteSpace(x.Name) ||
                       !string.IsNullOrWhiteSpace(x.MergeTag))
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
