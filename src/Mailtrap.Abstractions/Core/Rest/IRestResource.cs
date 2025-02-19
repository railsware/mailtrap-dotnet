// -----------------------------------------------------------------------
// <copyright file="IRestResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Rest;


/// <summary>
/// Generic interface for REST resource
/// </summary>
public interface IRestResource
{
    /// <summary>
    /// Gets resource absolute URI.
    /// </summary>
    ///
    /// <value>
    /// Absolute URI of the resource.
    /// </value>
    public Uri ResourceUri { get; }
}
