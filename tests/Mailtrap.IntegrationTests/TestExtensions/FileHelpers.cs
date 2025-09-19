namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class FileHelpers
{
    internal static async Task<StringContent> LoadFileToStringContent(
        this string featureFolderName,
        string? fileName = null,
        string fileExt = "json")
    {
        var fileString = await LoadFileToString(featureFolderName, fileName, fileExt);

        return new StringContent(fileString, System.Text.Encoding.UTF8, "application/json");
    }

    internal static async Task<string> LoadFileToString(
        this string featureFolderName,
        string? fileName = null,
        string fileExt = "json")
    {
        Ensure.NotNullOrEmpty(featureFolderName, nameof(featureFolderName));

        var name = $"{fileName ?? TestContext.CurrentContext.Test.MethodName ?? "Test"}.{fileExt}";
        var path = Path.Combine(featureFolderName, name);
        var fileString = await File.ReadAllTextAsync(path);

        return fileString;
    }
}
