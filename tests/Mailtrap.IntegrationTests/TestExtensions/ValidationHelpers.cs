namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class ValidationHelpers
{
    internal static async Task<TValue?> DeserializeStringContentAsync<TValue>(this StringContent responseContent, JsonSerializerOptions jsonSerializerOptions)
        where TValue : class
    {
        var responseStream = await responseContent.ReadAsStreamAsync();
        var expectedResponse = await JsonSerializer.DeserializeAsync<TValue>(responseStream, jsonSerializerOptions);
        responseStream.Position = 0; // Reset stream position
        return expectedResponse;
    }

    /// <summary>
    /// Compares two objects of the same type, handling JsonElement properties correctly.
    /// </summary>
    /// <typeparam name="TValue">Suppose to be <see cref="ContactResponse"/> and derived classes.</typeparam>
    /// <param name="result">Object with actial result</param>
    /// <param name="expected">Object with expected results</param>
    internal static void ShouldBeEquivalentToContactResponse<TValue>(this TValue result, TValue expected)
        where TValue : class
    {
        result.Should()
            .NotBeNull()
            .And
            .BeEquivalentTo(expected, options => options
            // Convert JsonElement to string before comparison
            // this should allow to correctly compare Dictionaty<string, object> like Contact.Fields
            .Using<JsonElement>(ctx =>
            {
                var expected = ctx.Expectation.ToString();
                var actual = ctx.Subject.ToString();
                actual.Should().Be(expected);
            }).WhenTypeIs<JsonElement>());
    }
}
