// -----------------------------------------------------------------------
// <copyright file="JsonSerializationOptionsProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Serialization;


/// <summary>
/// Provides default JSON serialization configuration for API calls
/// with camelCase naming policy, case-insensitive deserialization and indentation based on configuration.
/// </summary>
internal sealed class JsonSerializationOptionsProvider
{
    internal JsonSerializerOptions Options { get; }


    internal JsonSerializationOptionsProvider(IMailtrapApiClientConfigurationProvider configurationProvider)
    {
        Options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = configurationProvider.Configuration.Serialization.PrettyJson
        };
    }
}
