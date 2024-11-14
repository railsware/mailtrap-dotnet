// -----------------------------------------------------------------------
// <copyright file="UpdatePermissionsRequestItemTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.AccountAccesses.Requests;


[TestFixture]
internal sealed class UpdatePermissionsRequestItemTests
{
    private const long ResourceId = 42;
    private const AccessLevel ResourceAccessLevel = AccessLevel.Viewer;
    private readonly ResourceType _resourceType = ResourceType.Inbox;


    [Test]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenResourceIdIsZero()
    {
        var act = () => new UpdatePermissionsRequestItem(0, _resourceType, ResourceAccessLevel);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenResourceIdIsBelowZero()
    {
        var act = () => new UpdatePermissionsRequestItem(-34, _resourceType, ResourceAccessLevel);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenResourceTypeIsNull()
    {
        var act = () => new UpdatePermissionsRequestItem(ResourceId, null!, ResourceAccessLevel);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenResourceTypeIsNone()
    {
        var act = () => new UpdatePermissionsRequestItem(ResourceId, ResourceType.None, ResourceAccessLevel);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenAccessLevelIsInvalid([Values(0, 1, 42, 1000)] AccessLevel accessLevel)
    {
        var act = () => new UpdatePermissionsRequestItem(ResourceId, _resourceType, accessLevel);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var request = new UpdatePermissionsRequestItem(ResourceId, _resourceType, ResourceAccessLevel, true);

        request.ResourceId.Should().Be(ResourceId);
        request.ResourceType.Should().Be(_resourceType);
        request.AccessLevel.Should().Be(ResourceAccessLevel);
        request.Revoke.Should().Be(true);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenRequestIsValid()
    {
        var request = new UpdatePermissionsRequestItem(ResourceId, _resourceType, ResourceAccessLevel, true);

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
    }
}
