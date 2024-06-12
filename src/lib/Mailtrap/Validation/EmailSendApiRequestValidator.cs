// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Validators;


internal class EmailSendApiRequestValidator : AbstractValidator<EmailSendApiRequest>
{
    public static readonly EmailSendApiRequestValidator Instance = new();

    public EmailSendApiRequestValidator()
    {
        RuleFor(r => r.Sender!).NotNull().SetValidator(RecipientValidator.Instance);
        RuleFor(r => r.Subject).NotNull().MinimumLength(1);

        RuleFor(r => r.TextBody).NotNull().MinimumLength(1).When(r => string.IsNullOrEmpty(r.HtmlBody));
        RuleFor(r => r.HtmlBody).NotNull().MinimumLength(1).When(r => string.IsNullOrEmpty(r.TextBody));

        // TODO: Most likely some html validation should be added as well
        // to ensure valid serialization and sanity

        RuleFor(r => r.Recipients).Must(r => r.Count is > 0 and <= 1000);
        RuleForEach(r => r.Recipients).SetValidator(RecipientValidator.Instance);

        RuleFor(r => r.CarbonCopies).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.CarbonCopies).SetValidator(RecipientValidator.Instance);

        RuleFor(r => r.BlindCarbonCopies).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.BlindCarbonCopies).SetValidator(RecipientValidator.Instance);

        RuleForEach(r => r.Attachments).SetValidator(AttachmentValidator.Instance);
    }
}
