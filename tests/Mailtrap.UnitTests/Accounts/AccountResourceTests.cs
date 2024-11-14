// -----------------------------------------------------------------------
// <copyright file="AccountResourceTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using AccountAccessResource = Mailtrap.AccountAccesses.AccountAccessResource;


namespace Mailtrap.UnitTests.Accounts;


[TestFixture]
internal sealed class AccountResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.AccountsSegment)
        .Append(TestContext.CurrentContext.Random.NextLong());


    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        // Act
        var act = () => new AccountResource(null!, _resourceUri);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        // Act
        var act = () => new AccountResource(_commandFactoryMock, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ResourceUri_ShouldBeInitializedProperly()
    {
        // Arrange
        var client = CreateResource();

        // Assert
        client.ResourceUri.Should().Be(_resourceUri);
    }

    #endregion


    #region Billing
    [Test]
    public void Billing_ShouldReturnBillingResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Billing();

        // Assert
        VerifyResource<IBillingResource, BillingResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.BillingSegment));
    }
    #endregion


    #region Permissions
    [Test]
    public void Permissions_ShouldReturnPermissionsResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Permissions();

        // Assert
        VerifyResource<IPermissionsResource, PermissionsResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.PermissionsSegment));
    }
    #endregion


    #region Account Accesses

    [Test]
    public void Accesses_ShouldReturnAccessCollectionResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Accesses();

        // Assert
        VerifyResource<IAccountAccessCollectionResource, AccountAccessCollectionResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.AccountAccessesSegment));
    }

    [Test]
    public void Access_ShouldReturnAccessResource()
    {
        // Arrange
        var client = CreateResource();
        var accessId = TestContext.CurrentContext.Random.NextLong();

        // Act
        var result = client.Access(accessId);

        // Assert
        VerifyResource<IAccountAccessResource, AccountAccessResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.AccountAccessesSegment).Append(accessId));
    }

    #endregion


    private AccountResource CreateResource() => new(_commandFactoryMock, _resourceUri);

    private static void VerifyResource<TService, TImplementation>(TService result, Uri resourceUri)
        where TService : IRestResource
        where TImplementation : TService
    {
        result.Should()
            .NotBeNull().And
            .BeOfType<TImplementation>();

        result.ResourceUri.Should().Be(resourceUri);
    }
}
