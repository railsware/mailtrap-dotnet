namespace Mailtrap.Emails.Requests;


internal sealed class BatchSendEmailRequestValidator : AbstractValidator<BatchSendEmailRequest>
{
    public static BatchSendEmailRequestValidator Instance { get; } = new();

    public BatchSendEmailRequestValidator()
    {
        RuleFor(r => r.Requests)
            .NotEmpty();

        RuleFor(r => r.Requests.Count)
            .LessThanOrEqualTo(500)
            .When(r => r.Requests is not null);

        RuleForEach(r => r.Requests)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .SetValidator(SendEmailRequestValidator.Instance);
    }
}
