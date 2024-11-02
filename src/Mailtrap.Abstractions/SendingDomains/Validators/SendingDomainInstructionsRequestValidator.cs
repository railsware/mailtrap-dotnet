// -----------------------------------------------------------------------
// <copyright file="SendingDomainInstructionsRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Validators;


internal sealed class SendingDomainInstructionsRequestValidator : AbstractValidator<SendingDomainInstructionsRequest>
{
    public static SendingDomainInstructionsRequestValidator Instance { get; } = new();

    public SendingDomainInstructionsRequestValidator()
    {
        RuleFor(r => r.Email).NotNull().EmailAddress();
    }
}
