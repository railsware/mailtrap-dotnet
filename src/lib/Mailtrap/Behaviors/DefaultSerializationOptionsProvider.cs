// -----------------------------------------------------------------------
// <copyright file="DefaultSerializationOptionsProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Behaviors;


/// <summary>
/// Provides default JSON serialization option set, with camelCase naming policy,
/// case-insensitive deserialization and indentation turned on.
/// </summary>
internal class DefaultSerializationOptionsProvider : ISerializationOptionsProvider
{
    public static readonly DefaultSerializationOptionsProvider Instance = new();

    public JsonSerializerOptions Options { get; }


    internal DefaultSerializationOptionsProvider()
    {
        Options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
    }
}
