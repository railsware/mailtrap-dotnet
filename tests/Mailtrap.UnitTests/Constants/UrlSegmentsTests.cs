// -----------------------------------------------------------------------
// <copyright file="UrlSegmentsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Constants;


[TestFixture]
internal sealed class UrlSegmentsTests
{
    [Test]
    public void ApiRootSegment_ShouldContainCorrectValue()
    {
        UrlSegments.ApiRootSegment.Should().Be(UrlSegmentsTestConstants.ApiRootSegment);
    }
}
