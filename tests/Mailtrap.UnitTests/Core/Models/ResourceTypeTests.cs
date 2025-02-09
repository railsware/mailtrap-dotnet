// -----------------------------------------------------------------------
// <copyright file="ResourceTypeTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Core.Models;


[TestFixture]
internal sealed class ResourceTypeTests
{
    [Test]
    public void PredefinedEnumValuesShouldBeCorrect()
    {
        ResourceType.Account.ToString().Should().Be("account");
        ResourceType.Billing.ToString().Should().Be("billing");
        ResourceType.EmailCampaign.ToString().Should().Be("email_campaign_permission_scope");
        ResourceType.Inbox.ToString().Should().Be("inbox");
        ResourceType.Project.ToString().Should().Be("project");
        ResourceType.SendingDomain.ToString().Should().Be("sending_domain");
    }
}
