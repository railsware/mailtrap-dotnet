namespace Mailtrap.ApiTokens.Converters;


/// <summary>
/// Custom JSON converter to be used for <see cref="ApiTokenExpiration"/>.<br/>
/// Writes JSON <see langword="null"/> for <see cref="ApiTokenExpiration.Never"/>
/// and the ISO 8601 date-time string otherwise.
/// </summary>
internal sealed class ApiTokenExpirationJsonConverter : JsonConverter<ApiTokenExpiration>
{
    public override bool HandleNull => true;


    public override ApiTokenExpiration? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.Null => ApiTokenExpiration.Never,
            JsonTokenType.String => reader.TryGetDateTimeOffset(out var date)
                ? ApiTokenExpiration.At(date)
                : throw new JsonException($"Cannot convert value '{reader.GetString()}' to {nameof(ApiTokenExpiration)}."),
            _ => throw new JsonException($"Unexpected JSON token {reader.TokenType} for {nameof(ApiTokenExpiration)}.")
        };
    }

    public override void Write(Utf8JsonWriter writer, ApiTokenExpiration value, JsonSerializerOptions options)
    {
        Ensure.NotNull(writer, nameof(writer));
        Ensure.NotNull(value, nameof(value));

        if (value.Value.HasValue)
        {
            writer.WriteStringValue(value.Value.Value);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
