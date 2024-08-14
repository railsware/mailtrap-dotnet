// -----------------------------------------------------------------------
// <copyright file="Endpoint.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// A predefined set of channels/endpoints available for sending emails.
/// </summary>
public sealed record SendEndpoint
{
    /// <summary>
    /// Unspecified endpoint.<br/>
    /// For internal use.
    /// </summary>
    internal static SendEndpoint None { get; } = new(nameof(None));

    /// <summary>
    /// Endpoint for transactional send.
    /// </summary>
    public static SendEndpoint Transactional { get; } = new(nameof(Transactional));

    /// <summary>
    /// Endpoint for bulk send.
    /// </summary>
    public static SendEndpoint Bulk { get; } = new(nameof(Bulk));

    /// <summary>
    /// Endpoint for test send.
    /// </summary>
    public static SendEndpoint Test { get; } = new(nameof(Test));


    private readonly string _name;

    private SendEndpoint(string name)
    {
        _name = name;
    }


    // Overriding ToString only.
    // Valid equality and HashCode implementations are provided by the record OOB functionality.
    /// <inheritdoc />
    public override string ToString() => _name;
}
