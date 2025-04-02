namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class BatchEmailRequestValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenRequestsAreNull()
    {
        var request = new BatchEmailRequest()
        {
            Requests = null!
        };

        var result = BatchEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Requests);
    }

    [Test]
    public void Validation_ShouldFail_WhenRequestsAreEmpty()
    {
        var request = new BatchEmailRequest()
        {
            Requests = []
        };

        var result = BatchEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Requests);
    }

    [Test]
    public void Validation_ShouldFail_WhenRequestsCountIsGreaterThan500([Values(501)] int count)
    {
        var request = new BatchEmailRequest()
        {
            Requests = Enumerable.Repeat(new SendEmailRequest(), count).ToList()
        };

        var result = BatchEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Requests.Count);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenRequestsCountIsLessOrEqualTo500([Values(1, 500)] int count)
    {
        var request = new BatchEmailRequest()
        {
            Requests = Enumerable.Repeat(new SendEmailRequest(), count).ToList()
        };

        var result = BatchEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Requests.Count);
    }
}
