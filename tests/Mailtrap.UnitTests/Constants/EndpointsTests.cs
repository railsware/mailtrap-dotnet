// -----------------------------------------------------------------------
// <copyright file="EndpointsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Constants;


[TestFixture]
internal sealed class EndpointsTests
{
    [Test]
    public void ApiDefaultUrl_ShouldContainCorrectValue()
    {
        Endpoints.ApiDefaultUrl.Should().Be(EndpointsTestConstants.ApiDefaultUrl);
    }

    [Test]
    public void SendDefaultUrl_ShouldContainCorrectValue()
    {
        Endpoints.SendDefaultUrl.Should().Be(EndpointsTestConstants.SendDefaultUrl);
    }

    [Test]
    public void BulkDefaultUrl_ShouldContainCorrectValue()
    {
        Endpoints.BulkDefaultUrl.Should().Be(EndpointsTestConstants.BulkDefaultUrl);
    }

    [Test]
    public void TestDefaultUrl_ShouldContainCorrectValue()
    {
        Endpoints.TestDefaultUrl.Should().Be(EndpointsTestConstants.TestDefaultUrl);
    }
}
