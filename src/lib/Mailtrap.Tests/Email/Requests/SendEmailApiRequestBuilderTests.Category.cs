// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Category.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Category
{
    private string _category { get; } = "Category";


    [Test]
    public void WithCategory_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithCategory<RegularSendEmailApiRequest>(null!, _category);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCategory_ShouldNotThrowException_WhenCategoryIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCategory(request, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCategory_ShouldNotThrowException_WhenCategoryIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCategory(request, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCategory_ShouldAssignCategoryProperly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCategory(_category);

        request.Category.Should().BeSameAs(_category);
    }

    [Test]
    public void WithCategory_ShouldOverrideCategory_WhenCalledSeveralTimes()
    {
        var otherCategory = "Updated Category";

        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCategory(_category)
            .WithCategory(otherCategory);

        request.Category.Should().BeSameAs(otherCategory);
    }
}
