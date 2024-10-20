// -----------------------------------------------------------------------
// <copyright file="UpdateInboxRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Validators;


internal sealed class UpdateInboxRequestValidator : AbstractValidator<UpdateInboxRequest>
{
    public static UpdateInboxRequestValidator Instance { get; } = new();

    public UpdateInboxRequestValidator()
    {
        RuleFor(r => r)
            .Must(r => r.Name is not null || r.EmailUsername is not null)
            .WithName("Request")
            .WithMessage("There should be at least one field specified for update.");

        RuleFor(r => r.Name).NotEmpty().When(r => r.Name is not null);

        RuleFor(r => r.EmailUsername).NotEmpty().When(r => r.EmailUsername is not null);
    }
}
