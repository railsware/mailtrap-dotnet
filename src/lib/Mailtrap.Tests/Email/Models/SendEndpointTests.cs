// -----------------------------------------------------------------------
// <copyright file="DispositionTypeTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Models;


[TestFixture]
internal sealed class SendEndpointTests
{
    [Test]
    public void ToString_ShouldReturnInternalValue()
    {
        SendEndpoint.None.ToString().Should().Be(nameof(SendEndpoint.None));
        SendEndpoint.Transactional.ToString().Should().Be(nameof(SendEndpoint.Transactional));
        SendEndpoint.Bulk.ToString().Should().Be(nameof(SendEndpoint.Bulk));
        SendEndpoint.Test.ToString().Should().Be(nameof(SendEndpoint.Test));
    }
}
