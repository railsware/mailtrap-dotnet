// -----------------------------------------------------------------------
// <copyright file="Problem.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Models;


internal sealed record Problem
{
    /// <summary>
    /// Gets plain text error, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Error details.
    /// </value>
    [JsonPropertyName("error")]
    [JsonPropertyOrder(1)]
    public string? Error { get; set; }

    /// <summary>
    /// Gets errors, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Error(s) details.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(2)]
    public object? Errors { get; set; }


    public override string ToString()
    {
        var sb = new StringBuilder(Error);

        if (Errors is not null)
        {
            sb.AppendLine().Append(Errors);
        }

        return sb.ToString();
    }
}
