namespace Mailtrap.AccountAccesses.Validators;


internal sealed class UpdatePermissionsRequestValidator : AbstractValidator<UpdatePermissionsRequest>
{
    public static UpdatePermissionsRequestValidator Instance { get; } = new();

    public UpdatePermissionsRequestValidator()
    {
        RuleFor(r => r.Permissions).NotEmpty();
        RuleForEach(r => r.Permissions).SetValidator(UpdatePermissionsRequestItemValidator.Instance);
    }
}
