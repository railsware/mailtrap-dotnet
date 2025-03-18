namespace Mailtrap.Configuration;


internal sealed class MailtrapClientOptionsValidator : AbstractValidator<MailtrapClientOptions>
{
    public static MailtrapClientOptionsValidator Instance { get; } = new();

    public MailtrapClientOptionsValidator()
    {
        RuleFor(o => o.ApiToken).NotEmpty();
    }
}
