// -----------------------------------------------------------------------
// <copyright file="MailtrapClientSerializationOptionsExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Extensions;


internal static class MailtrapClientSerializationOptionsExtensions
{
    /// <summary>
    /// Converts <see cref="MailtrapClientSerializationOptions"/> instance to <see cref="JsonSerializerOptions"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="options"/> is <see langword="null"/>.
    /// </exception>
    internal static JsonSerializerOptions ToJsonSerializerOptions(this MailtrapClientSerializationOptions options)
    {
        Ensure.NotNull(options, nameof(options));

        return new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = options.PrettyJson
        };
    }
}
