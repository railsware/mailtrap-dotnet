// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientSerializationOptionsExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


internal static class MailtrapApiClientSerializationOptionsExtensions
{
    internal static JsonSerializerOptions ToJsonSerializerOptions(this MailtrapApiClientSerializationOptions options)
    {
        Ensure.NotNull(options, nameof(options));

        return new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = options.PrettyJson
        };
    }
}
