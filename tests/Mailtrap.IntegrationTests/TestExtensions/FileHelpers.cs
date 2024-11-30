// -----------------------------------------------------------------------
// <copyright file="FileHelpers.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class FileHelpers
{
    internal static async Task<StringContent> LoadFileToStringContent(
        this string featureFolderName,
        string? fileName = null,
        string filexExt = "json")
    {
        Ensure.NotNullOrEmpty(featureFolderName, nameof(featureFolderName));

        var name = $"{fileName ?? TestContext.CurrentContext.Test.MethodName ?? "Test"}.{filexExt}";
        var path = Path.Combine(featureFolderName, name);
        var responseString = await File.ReadAllTextAsync(path);

        return new StringContent(responseString);
    }
}
