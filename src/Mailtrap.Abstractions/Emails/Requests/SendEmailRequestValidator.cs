namespace Mailtrap.Emails.Requests;


internal sealed class SendEmailRequestValidator : AbstractValidator<SendEmailRequest>
{
    public static SendEmailRequestValidator Instance { get; } = new();

    public SendEmailRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(r => r)
            .SetValidator(EmailRequestValidator.Instance);

        RuleFor(r => r.To)
            .NotNull()
            .Must(r => r.Count is <= 1000);
        RuleForEach(r => r.To)
            .NotNull()
            .SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r.Cc)
            .NotNull()
            .Must(r => r.Count is <= 1000);
        RuleForEach(r => r.Cc)
            .NotNull()
            .SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r.Bcc)
            .NotNull()
            .Must(r => r.Count is <= 1000);
        RuleForEach(r => r.Bcc)
            .NotNull()
            .SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r)
            .Must(r => r.To.Count + r.Cc.Count + r.Bcc.Count > 0)
            .WithName("Recipients")
            .WithMessage("There should be at least one email recipient added to either To, Cc or Bcc.");
    }
}
