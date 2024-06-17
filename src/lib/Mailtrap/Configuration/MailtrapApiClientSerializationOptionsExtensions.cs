// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientSerializationOptionsExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Configuration;


internal static class MailtrapApiClientSerializationOptionsExtensions
{
    internal static JsonSerializerOptions ToJsonSerializerOptions(this MailtrapApiClientSerializationOptions options)
    {
        Ensure.NotNull(options, nameof(options));

        return new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = options.PrettyJson
        };
    }
}
