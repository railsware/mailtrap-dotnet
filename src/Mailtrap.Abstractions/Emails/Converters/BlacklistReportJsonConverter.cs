// -----------------------------------------------------------------------
// <copyright file="BlacklistReportJsonConverter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Converters;


/// <summary>
/// Custom JSON converter to be used for <see cref="BlacklistReport"/>.
/// </summary>
internal sealed class BlacklistReportJsonConverter : JsonConverter<BlacklistReport>
{
    private static readonly JsonConverter<BlacklistReport> s_defaultConverter =
        (JsonConverter<BlacklistReport>)JsonSerializerOptions.Default.GetConverter(typeof(BlacklistReport));


    public override BlacklistReport? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.False or JsonTokenType.True => null,
            _ => s_defaultConverter.Read(ref reader, typeToConvert, options)
        };
    }

    public override void Write(Utf8JsonWriter writer, BlacklistReport value, JsonSerializerOptions options)
        => s_defaultConverter.Write(writer, value, options);
}
