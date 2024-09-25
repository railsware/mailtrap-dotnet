// -----------------------------------------------------------------------
// <copyright file="Response.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Responses;


/// <summary>
/// Generic Mailtrap API response object.
/// </summary>
///
/// <typeparam name="TData">
/// Type of data associated with the response.
/// </typeparam>
public record Response<TData>
{
    /// <summary>
    /// Gets data associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Data associated with the response.
    /// </value>
    public TData Data { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="data">
    /// Data associated with the response.
    /// </param>
    public Response(TData data)
    {
        Ensure.NotNull(data, nameof(data));

        Data = data;
    }
}
