namespace Mailtrap.ContactImports.Validators;


/// <summary>
/// Validator for <see cref="CreateContactImportRequest"/>
/// Ensures the contact collection size is within allowed bounds (1-50,000) and each item is valid.
/// </summary>
internal sealed class ContactImportRequestValidator : AbstractValidator<CreateContactImportRequest>
{
    public const int MaxContactPerRequest = 50_000;
    public const int MinContactPerRequest = 1;
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static ContactImportRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public ContactImportRequestValidator()
    {
        RuleFor(r => r.Contacts)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(list => list.Count is >= MinContactPerRequest and <= MaxContactPerRequest);

        RuleForEach(r => r.Contacts)
            .NotNull()
            .SetValidator(ContactRequestValidator.Instance);
    }
}
