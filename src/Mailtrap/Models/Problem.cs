// -----------------------------------------------------------------------
// <copyright file="Problem.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


internal sealed record Problem
{
    /// <summary>
    /// Gets errors, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Error(s) details.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(1)]
    public object? Errors { get; set; }


    public override string ToString() => Errors?.ToString() ?? string.Empty;
}
