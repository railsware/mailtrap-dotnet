// -----------------------------------------------------------------------
// <copyright file="UpdatePermissionsRequestItemValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Validators;


internal sealed class UpdatePermissionsRequestItemValidator : AbstractValidator<UpdatePermissionsRequestItem>
{
    public static UpdatePermissionsRequestItemValidator Instance { get; } = new();

    public UpdatePermissionsRequestItemValidator()
    {
        RuleFor(r => r.ResourceId)
            .GreaterThan(0);

        RuleFor(r => r.ResourceType)
            .NotEmpty()
            .NotEqual(AccountResourceType.None);

        RuleFor(r => r.AccessLevel)
            .NotEmpty()
            .IsInEnum()
            .Must(l => l is AccessLevel.Admin or AccessLevel.Viewer);
    }
}
