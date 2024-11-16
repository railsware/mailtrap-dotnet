// -----------------------------------------------------------------------
// <copyright file="JsonHelpers.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class JsonHelpers
{
    internal static async Task<StringContent> LoadTestJsonToStringContent(this string featureFolderName, string? fileName = null)
    {
        Ensure.NotNullOrEmpty(featureFolderName, nameof(featureFolderName));

        var responseString = await File.ReadAllTextAsync(Path.Combine(featureFolderName, $"{fileName ?? TestContext.CurrentContext.Test.MethodName ?? "Test"}.json"));

        return new StringContent(responseString);
    }
}
