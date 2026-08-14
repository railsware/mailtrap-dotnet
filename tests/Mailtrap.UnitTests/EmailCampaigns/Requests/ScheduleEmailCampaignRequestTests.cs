namespace Mailtrap.UnitTests.EmailCampaigns.Requests;


[TestFixture]
internal sealed class ScheduleEmailCampaignRequestTests
{
    [Test]
    public void Validate_ShouldDelegateToValidator()
    {
        new ScheduleEmailCampaignRequest(DateTimeOffset.UtcNow.AddDays(7))
            .Validate().IsValid.Should().BeTrue();

        new ScheduleEmailCampaignRequest(DateTimeOffset.UtcNow.AddDays(-1))
            .Validate().IsValid.Should().BeFalse();
    }

    [Test]
    public void Serialize_ShouldEmitDatetimeAsIso8601()
    {
        // Arrange
        var request = new ScheduleEmailCampaignRequest(new DateTimeOffset(2026, 6, 1, 9, 0, 0, TimeSpan.Zero));

        // Act
        var json = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.Default);

        // Assert - "datetime" must be an ISO-8601 string, not .NET ticks or a Unix epoch number.
        json.Should().Contain("\"datetime\":\"2026-06-01T09:00:00");
        json.Should().NotContain("\"datetime\":637");
    }
}
