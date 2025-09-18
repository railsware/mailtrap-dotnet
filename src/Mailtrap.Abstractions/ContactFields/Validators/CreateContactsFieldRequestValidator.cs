namespace Mailtrap.ContactFields.Validators;


/// <summary>
/// Validator for Create contacts field requests.<br />
/// Ensures contacts field's Name and Merge Tag is not empty and length is within the allowed range.
/// </summary>
public sealed class CreateContactsFieldRequestValidator : AbstractValidator<CreateContactsFieldRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static CreateContactsFieldRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public CreateContactsFieldRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().Length(1, 80);
        RuleFor(r => r.MergeTag).NotEmpty().Length(1, 80);
    }
}
