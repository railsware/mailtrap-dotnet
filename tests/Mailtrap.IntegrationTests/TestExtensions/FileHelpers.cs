// -----------------------------------------------------------------------
// <copyright file="FileHelpers.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class FileHelpers
{
    internal static async Task<StringContent> LoadTestJsonToStringContent(
        this string featureFolderName,
        string? fileName = null,
        string filexExt = "json")
    {
        Ensure.NotNullOrEmpty(featureFolderName, nameof(featureFolderName));

        var responseString = await File.ReadAllTextAsync(Path.Combine(featureFolderName, $"{fileName ?? TestContext.CurrentContext.Test.MethodName ?? "Test"}.{filexExt}"));

        return new StringContent(responseString);
    }
}
