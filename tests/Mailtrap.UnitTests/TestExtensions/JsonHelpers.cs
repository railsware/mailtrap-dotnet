// -----------------------------------------------------------------------
// <copyright file="JsonHelpers.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.TestExtensions;


internal static class JsonHelpers
{
    internal static async Task<string> ReadTestJson(this string jsonFilePath)
    {
        Ensure.NotNullOrEmpty(jsonFilePath, nameof(jsonFilePath));

        return await File.ReadAllTextAsync(jsonFilePath);
    }
}
