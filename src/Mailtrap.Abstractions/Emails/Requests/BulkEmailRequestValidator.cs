namespace Mailtrap.Emails.Requests;


internal sealed class BulkEmailRequestValidator : AbstractValidator<BulkEmailRequest>
{
    public static BulkEmailRequestValidator Instance { get; } = new();

    public BulkEmailRequestValidator()
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
