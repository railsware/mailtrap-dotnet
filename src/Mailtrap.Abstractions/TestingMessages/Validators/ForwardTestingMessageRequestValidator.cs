namespace Mailtrap.TestingMessages.Validators;


internal sealed class ForwardTestingMessageRequestValidator : AbstractValidator<ForwardTestingMessageRequest>
{
    public static ForwardTestingMessageRequestValidator Instance { get; } = new();


    public ForwardTestingMessageRequestValidator()
    {
        RuleFor(r => r.Email).NotNull().EmailAddress();
    }
}
