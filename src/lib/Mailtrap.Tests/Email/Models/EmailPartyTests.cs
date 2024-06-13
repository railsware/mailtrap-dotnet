// -----------------------------------------------------------------------
// <copyright file="RecipientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Models;


[TestFixture]
internal sealed class EmailPartyTests
{
    [Test]
    public void ShouldThrowWhenEmptyEmailProvidedToConstructor()
    {
        var act = () => new EmailParty(string.Empty);

        act.Should().Throw<ArgumentException>();
    }
}
