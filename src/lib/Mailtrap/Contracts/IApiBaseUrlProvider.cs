// -----------------------------------------------------------------------
// <copyright file="IApiBaseUrlProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Contracts;


/// <summary>
/// Provides API host base URL
/// </summary>
internal interface IApiBaseUrlProvider
{
    Uri SendEmailHost { get; }
}
