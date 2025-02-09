// -----------------------------------------------------------------------
// <copyright file="ClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Core.Constants;


[TestFixture]
internal sealed class ClientTests
{
    [Test]
    public void Name_ShouldContainCorrectValue()
    {
        Client.Name.Should().Be(ClientTestConstants.Name);
    }
}
