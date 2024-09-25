// -----------------------------------------------------------------------
// <copyright file="CollectionResponse.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Responses;


/// <summary>
/// Generic Mailtrap API response object for collections.
/// </summary>
///
/// <typeparam name="TData">
/// Type of data associated with the response.
/// </typeparam>
public record CollectionResponse<TData> : Response<ICollection<TData>>
{
    /// <inheritdoc cref="Response{TData}.Response(TData)"/>
    public CollectionResponse(ICollection<TData> data) : base(data) { }
}
