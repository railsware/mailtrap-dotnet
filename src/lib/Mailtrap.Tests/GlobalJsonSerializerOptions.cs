// -----------------------------------------------------------------------
// <copyright file="GlobalJsonSerializerOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests;


internal static class GlobalJsonSerializerOptions
{
    public static JsonSerializerOptions NotIndented { get; } = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = false // Omit indentation to ensure desired output for tests
    };
}
