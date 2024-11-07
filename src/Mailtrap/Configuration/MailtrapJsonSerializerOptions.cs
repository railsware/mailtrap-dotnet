// -----------------------------------------------------------------------
// <copyright file="MailtrapJsonSerializerOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal static class MailtrapJsonSerializerOptions
{
    internal static JsonSerializerOptions Default { get; } = new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new StringEnumJsonConverterFactory()
        }
    };

    internal static JsonSerializerOptions NotIndented { get; } = new JsonSerializerOptions(Default)
    {
        WriteIndented = false
    };
}
