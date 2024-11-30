// -----------------------------------------------------------------------
// <copyright file="ForwardTestingMessageRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Validators;


internal sealed class ForwardTestingMessageRequestValidator : AbstractValidator<ForwardTestingMessageRequest>
{
    public static ForwardTestingMessageRequestValidator Instance { get; } = new();


    public ForwardTestingMessageRequestValidator()
    {
        RuleFor(r => r.Email).NotNull().EmailAddress();
    }
}
