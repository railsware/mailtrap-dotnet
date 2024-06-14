// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// A set of helper methods to streamline <see cref="SendEmailApiRequest"/> instance construction in a fluent style.
/// </summary>
public static partial class SendEmailApiRequestBuilder
{
    /// <summary>
    /// Creates a new instance of request of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Api request type, derived from <see cref="SendEmailApiRequest"/></typeparam>
    /// <returns></returns>
    public static T Create<T>() where T : SendEmailApiRequest, new() => new();
}
