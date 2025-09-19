namespace Mailtrap.ContactLists.Validators;


/// <summary>
/// Validator for Create/Update contacts list requests.<br/>
/// Ensures contacts list's name is not empty and length is within the allowed range.
/// </summary>
public sealed class ContactsListRequestValidator : AbstractValidator<ContactsListRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static ContactsListRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public ContactsListRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().Length(1, 255);
    }
}
