namespace Mailtrap.ContactImports.Validators;


/// <summary>
/// Validator for Create/Update contact requests.<br />
/// Ensures contact's email is not empty and length is within the allowed range.
/// </summary>
internal sealed class ContactsImportRequestValidator : AbstractValidator<ContactsImportRequest>
{
    public const int MaxContactsPerRequest = 50_000;
    public const int MinContactsPerRequest = 1;
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static ContactsImportRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public ContactsImportRequestValidator()
    {
        RuleFor(r => r.Contacts)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(list => list != null && list.Count is >= MinContactsPerRequest and <= MaxContactsPerRequest);

        RuleForEach(r => r.Contacts)
            .NotNull()
            .SetValidator(ContactRequestValidator.Instance);
    }
}
