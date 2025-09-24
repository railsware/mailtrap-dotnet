namespace Mailtrap.ContactFields.Validators;


/// <summary>
/// Validator for <see cref="UpdateContactFieldRequest"/> requests.<br />
/// Ensures that at least one of Name or MergeTag is provided, with a maximum length of 80 characters.
/// </summary>
public sealed class UpdateContactFieldRequestValidator : AbstractValidator<UpdateContactFieldRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static UpdateContactFieldRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public UpdateContactFieldRequestValidator()
    {
        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.Name) ||
                       !string.IsNullOrEmpty(x.MergeTag))
            .WithMessage(x => $"At least one of {nameof(x.Name)} or {nameof(x.MergeTag)} must be provided.");

        When(x => !string.IsNullOrEmpty(x.Name), () =>
        {
            RuleFor(r => r.Name).NotEmpty().MaximumLength(80);
        });

        When(x => !string.IsNullOrEmpty(x.MergeTag), () =>
        {
            RuleFor(r => r.MergeTag).NotEmpty().MaximumLength(80);
        });
    }
}
