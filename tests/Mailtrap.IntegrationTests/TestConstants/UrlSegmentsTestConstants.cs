// -----------------------------------------------------------------------
// <copyright file="UrlSegmentsTestConstants.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.IntegrationTests.TestConstants;


internal static class UrlSegmentsTestConstants
{
    internal static string ApiRootSegment { get; } = "api";
    internal static string AccountsSegment { get; } = "accounts";
    internal static string BillingSegment { get; } = "billing";
    internal static string BillingUsageSegment { get; } = "usage";
    internal static string PermissionsSegment { get; } = "permissions";
    internal static string PermissionsForResourcesSegment { get; } = "resources";
    internal static string AccountAccessesSegment { get; } = "account_accesses";
    internal static string ProjectsSegment { get; } = "projects";
    internal static string InboxesSegment { get; } = "inboxes";
    internal static string SendingDomainsSegment { get; } = "sending_domains";
    internal static string SendingDomainsSendSetupInstructionsSegment { get; } = "send_setup_instructions";
    internal static string EmailsSegment { get; } = "messages";
    internal static string SendEmailSegment { get; } = "send";
}
