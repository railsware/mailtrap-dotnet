// -----------------------------------------------------------------------
// <copyright file="DispositionTypeJsonConverter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Converters;


/// <summary>
/// Custom JSON converter to be used for <see cref="DispositionType"/>
/// </summary>
internal sealed class DispositionTypeJsonConverter : JsonConverter<DispositionType>
{
    /// <inheritdoc />
    /// <exception cref="JsonException"></exception>
    public override DispositionType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString() ?? string.Empty;
            var comparison = options.PropertyNameCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            if (string.Equals(stringValue, DispositionType.Inline.ToString(), comparison))
            {
                return DispositionType.Inline;
            }

            if (string.Equals(stringValue, DispositionType.Attachment.ToString(), comparison))
            {
                return DispositionType.Attachment;
            }
        }

        throw new JsonException($"Unsupported token type: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, DispositionType value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());
}
