// -----------------------------------------------------------------------
// <copyright file="GlobalJsonSerializerOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal static class MailtrapJsonSerializerOptions
{
    internal static JsonSerializerOptions Default { get; } = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    internal static JsonSerializerOptions NotIndented { get; } = new JsonSerializerOptions(Default)
    {
        WriteIndented = false
    };
}
