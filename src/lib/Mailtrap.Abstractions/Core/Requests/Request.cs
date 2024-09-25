// -----------------------------------------------------------------------
// <copyright file="Request.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Requests;


/// <summary>
/// Generic Mailtrap API request object.
/// </summary>
///
/// <typeparam name="TData">
/// Type of data associated with the request.
/// </typeparam>
public record Request<TData>
{
    /// <summary>
    /// Gets data associated with the request.
    /// </summary>
    ///
    /// <value>
    /// Data associated with the request.
    /// </value>
    public TData? Data { get; set; }
}
