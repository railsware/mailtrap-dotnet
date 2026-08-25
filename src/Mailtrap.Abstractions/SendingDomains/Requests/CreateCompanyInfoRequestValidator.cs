namespace Mailtrap.SendingDomains.Requests;


internal sealed class CreateCompanyInfoRequestValidator : AbstractValidator<CreateCompanyInfoRequest>
{
    public static CreateCompanyInfoRequestValidator Instance { get; } = new();

    public CreateCompanyInfoRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Address).NotEmpty();
        RuleFor(r => r.City).NotEmpty();
        RuleFor(r => r.Country).NotEmpty();
        RuleFor(r => r.ZipCode).NotEmpty();
        RuleFor(r => r.WebsiteUrl).NotNull();
    }
}
