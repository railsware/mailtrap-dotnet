// -----------------------------------------------------------------------
// <copyright file="BlacklistReportResult.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Models;


/// <summary>
/// Represents the overall result for the blacklist report.
/// </summary>
public sealed record BlacklistReportResult : StringEnum<BlacklistReportResult>
{
    /// <summary>
    /// Gets the value representing "pending" result.
    /// </summary>
    ///
    /// <value>
    /// Represents "pending" result.
    /// </value>
    public static BlacklistReportResult Pending { get; } = Define("pending");

    /// <summary>
    /// Gets the value representing "success" result.
    /// </summary>
    ///
    /// <value>
    /// Represents "success" result.
    /// </value>
    public static BlacklistReportResult Success { get; } = Define("success");

    /// <summary>
    /// Gets the value representing "error" result.
    /// </summary>
    ///
    /// <value>
    /// Represents "error" result.
    /// </value>
    public static BlacklistReportResult Error { get; } = Define("error");
}
