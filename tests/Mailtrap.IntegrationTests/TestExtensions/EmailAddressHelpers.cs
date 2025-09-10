namespace Mailtrap.IntegrationTests.TestExtensions;


internal static class EmailAddressHelpers
{


    /// <summary>
    /// Generates a random email address with the specified domain.
    /// </summary>
    /// <param name="random">Randomizer instance</param>
    /// <param name="domain">Optional domain name</param>
    /// <param name="outputLength">Total output length including domain.
    /// Minimum length depends on the domain name length.</param>
    /// <returns>Random email address</returns>
    public static string NextEmail(this NUnit.Framework.Internal.Randomizer random, int? outputLength = null, string? domain = null)
    {
        // domain name: at least 3 symbols (ex, "abc.org")
        // TLD: minimum 2 symbols (ex, ".io")
        const int minDomainNameLen = 3;
        const int minTldLen = 2;
        const int defaultUsernameLength = 8;
        var atSymbol = "@";
        string domainPart;

        if (string.IsNullOrWhiteSpace(domain))
        {
            var domainName = random.GetString(minDomainNameLen);
            var tld = random.GetString(minTldLen);
            domainPart = $"{domainName}.{tld}";
        }
        else
        {
            domainPart = domain.TrimStart('@');
        }

        // Minimum email length: username (1) + '@' (1) + minimum domain (3) + '.' (1) + TLD (2)
        var minEmailLength = 1 + atSymbol.Length + domainPart.Length;

        // Explicit check for valid outputLength
        if (outputLength.HasValue && outputLength < minEmailLength)
        {
            return random.GetString(outputLength.Value);
        }

        // Generation of username with optimal length
        var usernameLength = outputLength - atSymbol.Length - domainPart.Length;
        var username = random.GetString(usernameLength ?? defaultUsernameLength);

        return $"{username}{atSymbol}{domainPart}";
    }
}
