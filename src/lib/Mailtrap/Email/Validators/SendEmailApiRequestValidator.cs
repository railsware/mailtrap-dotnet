// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Email.Validators;


internal class SendEmailApiRequestValidator : AbstractValidator<SendEmailApiRequest>
{
    public static SendEmailApiRequestValidator Instance { get; } = new();

    public SendEmailApiRequestValidator()
    {
        RuleFor(r => r.Sender!).NotNull().SetValidator(EmailPartyValidator.Instance);

        RuleFor(r => r.Recipients).Must(r => r.Count is > 0 and <= 1000);
        RuleForEach(r => r.Recipients).SetValidator(EmailPartyValidator.Instance);

        RuleFor(r => r.CarbonCopies).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.CarbonCopies).SetValidator(EmailPartyValidator.Instance);

        RuleFor(r => r.BlindCarbonCopies).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.BlindCarbonCopies).SetValidator(EmailPartyValidator.Instance);

        RuleForEach(r => r.Attachments).SetValidator(AttachmentValidator.Instance);
    }
}
