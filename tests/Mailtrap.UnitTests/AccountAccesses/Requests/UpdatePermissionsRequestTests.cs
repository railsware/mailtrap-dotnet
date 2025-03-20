namespace Mailtrap.UnitTests.AccountAccesses.Requests;


[TestFixture]
internal sealed class UpdatePermissionsRequestTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenPermissionsIsNull()
    {
        var act = () => new UpdatePermissionsRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Validation_ShouldFail_WhenNoPermissionsSpecified()
    {
        var request = new UpdatePermissionsRequest();

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validation_ShouldNotFail_WhenRequestIsValid()
    {
        var request = new UpdatePermissionsRequest(
            new UpdatePermissionsRequestItem(42, ResourceType.Project, AccessLevel.Admin));

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
    }
}
