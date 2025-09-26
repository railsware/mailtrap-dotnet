namespace Mailtrap.ContactFields.Validators;


/// <summary>
/// Validator for <see cref="CreateContactFieldRequest"/> requests.<br />
/// Ensures that the contact field’s Name and MergeTag are not empty and do not exceed 80 characters each.
/// </summary>
public sealed class CreateContactFieldRequestValidator : AbstractValidator<CreateContactFieldRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static CreateContactFieldRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public CreateContactFieldRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().MaximumLength(80);
        RuleFor(r => r.MergeTag).NotEmpty().MaximumLength(80);
    }
}
