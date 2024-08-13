// -----------------------------------------------------------------------
// <copyright file="Endpoint.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// A predefined set of channels/endpoints available for sending emails.
/// </summary>
public enum Endpoint
{
    /// <summary>
    /// Endpoint for transactional send.
    /// </summary>
    Send = 0,

    /// <summary>
    /// Endpoint for bulk send.
    /// </summary>
    Bulk,

    /// <summary>
    /// Endpoint for test send.
    /// </summary>
    Test
}
