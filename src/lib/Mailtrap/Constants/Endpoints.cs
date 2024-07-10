// -----------------------------------------------------------------------
// <copyright file="Endpoints.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Constants;


/// <summary>
/// Contains predefined default API endpoints for Mailtrap.
/// </summary>
internal static class Endpoints
{
    /// <summary>
    /// Default base URL for Mailtrap API endpoint.<br />
    /// <see href="https://api-docs.mailtrap.io/docs/mailtrap-api-docs/82708d3cc9606-general"/>
    /// </summary>
    internal static string ApiDefaultUrl { get; } = "https://mailtrap.io";

    /// <summary>
    /// Default base URL for Mailtrap API send endpoint.<br />
    /// <see href="https://api-docs.mailtrap.io/docs/mailtrap-api-docs/67f1d70aeb62c-send-email-including-templates"/>
    /// </summary>
    internal static string SendDefaultUrl { get; } = "https://send.api.mailtrap.io";

    /// <summary>
    /// Default base URL for Mailtrap API send endpoint.<br />
    /// <see href="https://api-docs.mailtrap.io/docs/mailtrap-api-docs/711042a37477c-send-email-including-templates"/>
    /// </summary>
    internal static string BulkDefaultUrl { get; } = "https://bulk.api.mailtrap.io";

    /// <summary>
    /// Default base URL for Mailtrap API test endpoint.<br />
    /// <see href="https://api-docs.mailtrap.io/docs/mailtrap-api-docs/bcf61cdc1547e-send-email-including-templates"/>
    /// </summary>
    internal static string TestDefaultUrl { get; } = "https://sandbox.api.mailtrap.io";

}
