// -----------------------------------------------------------------------
// <copyright file="MailtrapClientSerializationOptionsExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal static class MailtrapClientSerializationOptionsExtensions
{
    internal static JsonSerializerOptions ToJsonSerializerOptions(this MailtrapClientSerializationOptions options)
    {
        Ensure.NotNull(options, nameof(options));

        return new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = options.PrettyJson
        };
    }
}
