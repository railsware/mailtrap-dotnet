// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal static class MailtrapClientOptionsExtensions
{
    /// <summary>
    /// Gets specific endpoint settings from the client configuration.
    /// </summary>
    /// <param name="options">Client configuration.</param>
    /// <param name="endpoint">Endpoint, which settings are needed.</param>
    /// <returns><see cref="MailtrapClientEndpointOptions"/> for specific endpoint.</returns>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="options"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// When provided <paramref name="endpoint"/> is not known value.
    /// </exception>
    internal static MailtrapClientEndpointOptions GetEndpoint(this MailtrapClientOptions options, Endpoint endpoint)
    {
        Ensure.NotNull(options, nameof(options));

        return endpoint switch
        {
            Endpoint.Send => options.SendEndpoint,
            Endpoint.Bulk => options.BulkEndpoint,
            Endpoint.Test => options.TestEndpoint,
            _ => throw new ArgumentOutOfRangeException(nameof(endpoint), endpoint, "Unknown endpoint type.")
        };
    }
}
