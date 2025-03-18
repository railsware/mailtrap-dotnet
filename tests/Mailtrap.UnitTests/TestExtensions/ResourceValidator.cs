namespace Mailtrap.UnitTests.TestExtensions;


internal static class ResourceValidator
{
    public static void Validate<TService, TImplementation>(TService result, Uri resourceUri)
        where TService : IRestResource
        where TImplementation : TService
    {
        result.Should()
            .NotBeNull().And
            .BeOfType<TImplementation>();

        result.ResourceUri.Should().Be(resourceUri);
    }
}
