namespace Mailtrap.Emails.Validators;


internal sealed class EmailAddressValidator : AbstractValidator<EmailAddress>
{
    public static EmailAddressValidator Instance { get; } = new();

    public EmailAddressValidator()
    {
        RuleFor(r => r.Email).NotNull().EmailAddress();
    }
}
