namespace Mailtrap.Emails.Requests;


internal sealed class BatchEmailRequestValidator : AbstractValidator<BatchEmailRequest>
{
    public static BatchEmailRequestValidator Instance { get; } = new();

    public BatchEmailRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(r => r.Requests)
            .NotEmpty();

        RuleFor(r => r.Requests.Count)
            .LessThanOrEqualTo(500);
    }
}
