// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Converters;


/// <summary>
/// Custom JSON converter to be used for <see cref="StringEnum{T}"/>.
/// </summary>
internal sealed class StringEnumJsonConverter<T> : JsonConverter<T> where T : StringEnum<T>, new()
{
    /// <inheritdoc />
    /// <exception cref="JsonException"></exception>
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => StringEnum<T>.Find(reader.GetString()),
            _ => throw new JsonException($"Unsupported token type: {reader.TokenType}")
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        Ensure.NotNull(writer, nameof(writer));

        writer.WriteStringValue(value?.ToString());
    }
}
