namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class FileHelpers
{
    internal static async Task<StringContent> LoadFileToStringContent(
        this string featureFolderName,
        string? fileName = null,
        string filexExt = "json")
    {
        var fileString = await LoadFileToString(featureFolderName, fileName, filexExt);

        return new StringContent(fileString);
    }

    internal static async Task<string> LoadFileToString(
        this string featureFolderName,
        string? fileName,
        string filexExt = "json")
    {
        Ensure.NotNullOrEmpty(featureFolderName, nameof(featureFolderName));

        var name = $"{fileName ?? TestContext.CurrentContext.Test.MethodName ?? "Test"}.{filexExt}";
        var path = Path.Combine(featureFolderName, name);
        var fileString = await File.ReadAllTextAsync(path);

        return fileString;
    }
}
