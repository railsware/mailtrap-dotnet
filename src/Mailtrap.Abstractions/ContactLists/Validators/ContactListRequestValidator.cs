namespace Mailtrap.ContactLists.Validators;


/// <summary>
/// Validator for <see cref="ContactListRequest"/> requests.<br/>
/// Ensures contact list's name is not empty and length isn't exceed 255 characters.
/// </summary>
public sealed class ContactListRequestValidator : AbstractValidator<ContactListRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static ContactListRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public ContactListRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().MaximumLength(255);
    }
}
