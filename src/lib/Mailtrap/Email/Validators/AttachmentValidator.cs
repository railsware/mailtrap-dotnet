// -----------------------------------------------------------------------
// <copyright file="AttachmentValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Validators;


internal class AttachmentValidator : AbstractValidator<Attachment>
{
    public static AttachmentValidator Instance { get; } = new();

    public AttachmentValidator()
    {
        RuleFor(a => a.Content).NotNull().MinimumLength(1);
        RuleFor(a => a.FileName).NotNull();
        RuleFor(a => a.MimeType).MinimumLength(1).When(a => a.MimeType is not null);
    }
}
