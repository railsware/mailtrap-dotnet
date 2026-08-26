using System.Globalization;

namespace Mailtrap.UnitTests.ApiTokens;


[TestFixture]
internal sealed class ApiTokenExpirationTests
{
    private const string ExpirationDateRaw = "2027-06-01T00:00:00Z";
    private const string ExpirationDateSerialized = "2027-06-01T00:00:00+00:00";

    private static readonly DateTimeOffset s_expirationDate =
        DateTimeOffset.Parse(ExpirationDateRaw, CultureInfo.InvariantCulture);

    // Options that do NOT ignore nulls, unlike the ones the SDK uses for its own requests.
    private static readonly JsonSerializerOptions s_nullWritingOptions = new();


    #region CreateApiTokenRequest serialization

    [Test]
    public void CreateRequest_ShouldOmitExpiresAtKey_WhenExpirationIsNotSet()
    {
        var request = new CreateApiTokenRequest { Name = "My API Token" };

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be("""{"name":"My API Token","resources":[]}""");
    }

    [Test]
    public void CreateRequest_ShouldWriteNullExpiresAt_WhenExpirationIsNever()
    {
        var request = new CreateApiTokenRequest
        {
            Name = "My API Token",
            ExpiresAt = ApiTokenExpiration.Never
        };

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be("""{"name":"My API Token","expires_at":null,"resources":[]}""");
    }

    [Test]
    public void CreateRequest_ShouldWriteIsoStringExpiresAt_WhenExpirationIsSet()
    {
        var request = new CreateApiTokenRequest
        {
            Name = "My API Token",
            ExpiresAt = ApiTokenExpiration.At(s_expirationDate)
        };

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be($$"""{"name":"My API Token","expires_at":"{{ExpirationDateSerialized}}","resources":[]}""");
    }

    #endregion


    #region ResetApiTokenRequest serialization

    [Test]
    public void ResetRequest_ShouldOmitExpiresAtKey_WhenExpirationIsNotSet()
    {
        var request = new ResetApiTokenRequest();

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be("{}");
    }

    [Test]
    public void ResetRequest_ShouldWriteNullExpiresAt_WhenExpirationIsNever()
    {
        var request = new ResetApiTokenRequest { ExpiresAt = ApiTokenExpiration.Never };

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be("""{"expires_at":null}""");
    }

    [Test]
    public void ResetRequest_ShouldWriteIsoStringExpiresAt_WhenExpirationIsSet()
    {
        var request = new ResetApiTokenRequest { ExpiresAt = ApiTokenExpiration.At(s_expirationDate) };

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be($$"""{"expires_at":"{{ExpirationDateSerialized}}"}""");
    }

    #endregion


    #region Null serialization

    [Test]
    public void Converter_ShouldWriteJsonNull_WhenExpirationReferenceIsNull()
    {
        ApiTokenExpiration? expiration = null;

        var serialized = JsonSerializer.Serialize(expiration, s_nullWritingOptions);

        serialized.Should().Be("null");
    }

    [Test]
    public void ResetRequest_ShouldWriteNullExpiresAt_WhenNullsAreNotIgnored()
    {
        var request = new ResetApiTokenRequest { ExpiresAt = null };

        var serialized = JsonSerializer.Serialize(request, s_nullWritingOptions);

        serialized.Should().Be("""{"expires_at":null}""");
    }

    #endregion


    #region Deserialization

    [Test]
    public void CreateRequest_ShouldDeserializeMissingExpiresAt_ToNull()
    {
        var deserialized = JsonSerializer.Deserialize<CreateApiTokenRequest>(
            """{"name":"My API Token","resources":[]}""",
            MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().NotBeNull();
        deserialized!.ExpiresAt.Should().BeNull();
    }

    [Test]
    public void CreateRequest_ShouldDeserializeNullExpiresAt_ToNever()
    {
        var deserialized = JsonSerializer.Deserialize<CreateApiTokenRequest>(
            """{"name":"My API Token","expires_at":null,"resources":[]}""",
            MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().NotBeNull();
        deserialized!.ExpiresAt.Should().Be(ApiTokenExpiration.Never);
    }

    [Test]
    public void ResetRequest_ShouldDeserializeStringExpiresAt_ToExpirationAtDate()
    {
        var deserialized = JsonSerializer.Deserialize<ResetApiTokenRequest>(
            $$"""{"expires_at":"{{ExpirationDateRaw}}"}""",
            MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().NotBeNull();
        deserialized!.ExpiresAt.Should().Be(ApiTokenExpiration.At(s_expirationDate));
    }

    [Test]
    public void ResetRequest_ShouldThrowJsonException_WhenExpiresAtIsNotParseable()
    {
        var act = () => JsonSerializer.Deserialize<ResetApiTokenRequest>(
            """{"expires_at":"not-a-date"}""",
            MailtrapJsonSerializerOptions.NotIndented);

        act.Should().Throw<JsonException>();
    }

    #endregion
}
