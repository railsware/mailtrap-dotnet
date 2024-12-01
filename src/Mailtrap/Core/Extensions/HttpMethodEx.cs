// -----------------------------------------------------------------------
// <copyright file="HttpMethodEx.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Extensions;


/// <summary>
/// A set of extensions for <see cref="HttpMethod"/>.
/// </summary>
internal static class HttpMethodEx
{
    internal static HttpMethod Patch { get; } = new HttpMethod("PATCH");
}
