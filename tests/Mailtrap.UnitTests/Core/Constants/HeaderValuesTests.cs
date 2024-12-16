// -----------------------------------------------------------------------
// <copyright file="HeaderValuesTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Core.Constants;


[TestFixture]
internal sealed class HeaderValuesTests
{
    [Test]
    public void UserAgentName_ShouldContainCorrectValue()
    {
        HeaderValues.UserAgentName.Should().Be(HeaderValuesTestConstants.UserAgentName);
    }
}
