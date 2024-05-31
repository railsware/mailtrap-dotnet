// -----------------------------------------------------------------------
// <copyright file="MessageIdJsonConverter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Text.Json;


namespace Mailtrap.Converters;


/// <summary>
/// Custom JSON converter to be used for <see cref="MessageId"/>
/// </summary>
internal sealed class MessageIdJsonConverter : JsonConverter<MessageId>
{
    public override MessageId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType == JsonTokenType.String
            ? new MessageId(reader.GetString() ?? string.Empty)
            : throw new JsonException($"Unsupported token type: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, MessageId value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());
}
