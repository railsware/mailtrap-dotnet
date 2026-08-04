namespace Mailtrap.Inbound.Validators;


/// <summary>
/// Validator for <see cref="ForwardInboundMessageRequest"/>.<br/>
/// Ensures at least one <c>To</c> recipient is provided.
/// </summary>
public sealed class ForwardInboundMessageRequestValidator : AbstractValidator<ForwardInboundMessageRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static ForwardInboundMessageRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public ForwardInboundMessageRequestValidator()
    {
        RuleFor(r => r.To)
            .NotEmpty()
            .WithMessage("'To' must contain at least one recipient for a forward.");
    }
}
