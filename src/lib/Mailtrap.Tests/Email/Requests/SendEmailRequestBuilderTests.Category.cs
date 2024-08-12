// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.Category.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_Category
{
    private string _category { get; } = "Category";


    [Test]
    public void Category_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.Category(null!, _category);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Category_ShouldNotThrowException_WhenCategoryIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Category(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Category_ShouldNotThrowException_WhenCategoryIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Category(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Category_ShouldAssignCategoryProperly()
    {
        var request = SendEmailRequest
            .Create()
            .Category(_category);

        request.Category.Should().BeSameAs(_category);
    }

    [Test]
    public void Category_ShouldOverrideCategory_WhenCalledSeveralTimes()
    {
        var otherCategory = "Updated Category";

        var request = SendEmailRequest
            .Create()
            .Category(_category)
            .Category(otherCategory);

        request.Category.Should().BeSameAs(otherCategory);
    }
}
