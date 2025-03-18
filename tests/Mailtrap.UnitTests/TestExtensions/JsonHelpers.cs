namespace Mailtrap.UnitTests.TestExtensions;


internal static class JsonHelpers
{
    internal static async Task<string> ReadTestJson(this string jsonFilePath)
    {
        Ensure.NotNullOrEmpty(jsonFilePath, nameof(jsonFilePath));

        return await File.ReadAllTextAsync(jsonFilePath);
    }
}
