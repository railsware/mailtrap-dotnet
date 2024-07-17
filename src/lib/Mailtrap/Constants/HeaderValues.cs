// -----------------------------------------------------------------------
// <copyright file="HeaderValues.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Constants;


/// <summary>
/// HTTP header values used in Mailtrap API.
/// </summary>
internal static class HeaderValues
{
    internal static string UserAgent { get; } = "mailtrap-dotnet";
    internal static string UserAgentVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
}
