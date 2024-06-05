// -----------------------------------------------------------------------
// <copyright file="IJsonSerializerFacade.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Serialization;


public interface IJsonSerializerFacade
{
    T? Deserialize<T>(string value);
    string Serialize<T>(T value);
}
