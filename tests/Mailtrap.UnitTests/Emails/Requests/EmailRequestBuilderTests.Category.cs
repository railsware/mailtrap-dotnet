namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture(TestOf = typeof(EmailRequestBuilder))]
internal sealed class EmailRequestBuilderTests_Category
{
    private string _category { get; } = "Category";


    [Test]
    public void Category_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => EmailRequestBuilder.Category<EmailRequest>(null!, _category);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Category_ShouldNotThrowException_WhenCategoryIsNull()
    {
        var request = EmailRequest.Create();

        var act = () => request.Category(null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Category_ShouldNotThrowException_WhenCategoryIsEmpty()
    {
        var request = EmailRequest.Create();

        var act = () => request.Category(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Category_ShouldAssignCategoryProperly()
    {
        var request = EmailRequest
            .Create()
            .Category(_category);

        request.Category.Should().BeSameAs(_category);
    }

    [Test]
    public void Category_ShouldOverrideCategory_WhenCalledSeveralTimes()
    {
        var otherCategory = "Updated Category";

        var request = EmailRequest
            .Create()
            .Category(_category)
            .Category(otherCategory);

        request.Category.Should().BeSameAs(otherCategory);
    }
}
