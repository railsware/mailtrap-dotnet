namespace Mailtrap.Contacts.Converters;

/// <summary>
/// Converts DateTime to ticks for JSON serialization.
/// </summary>
internal sealed class DateTimeToTicksJsonConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new DateTimeOffset(reader.GetInt64(), TimeSpan.Zero);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Ticks);
    }
}
