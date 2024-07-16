// -----------------------------------------------------------------------
// <copyright file="Endpoint.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


/// <summary>
/// Enum of available send channels/endpoints.
/// </summary>
public enum Endpoint
{
    /// <summary>
    /// Send endpoint.
    /// </summary>
    Send = 0,

    /// <summary>
    /// Bulk endpoint.
    /// </summary>
    Bulk,

    /// <summary>
    /// Test endpoint.
    /// </summary>
    Test
}
