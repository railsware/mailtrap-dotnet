namespace Mailtrap.Emails.Requests;


internal sealed class BatchEmailRequestValidator : AbstractValidator<BatchEmailRequest>
{
    public static BatchEmailRequestValidator Instance { get; } = new();

    public BatchEmailRequestValidator()
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
