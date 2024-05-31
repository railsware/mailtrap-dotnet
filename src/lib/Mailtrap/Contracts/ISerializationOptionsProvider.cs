// -----------------------------------------------------------------------
// <copyright file="ISerializationOptionsProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Contracts;


/// <summary>
/// Provides default JSON serialization configuration
/// </summary>
internal interface ISerializationOptionsProvider
{
    // TODO: This one exposes implementation detail, but for now I believe it is fine.
    // Probably later we can create a higher level abstraction for request/response serialization that 
    // will allow us to replace implementation in case of need.

    JsonSerializerOptions Options { get; }
}
