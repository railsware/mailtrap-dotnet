// -----------------------------------------------------------------------
// <copyright file="JsonSerializerFacade.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Serialization;


internal sealed class JsonSerializerFacade : IJsonSerializerFacade
{
    private readonly JsonSerializerOptions _options;


    public JsonSerializerFacade(JsonSerializationOptionsProvider optionsProvider)
    {
        _options = optionsProvider.Options;
    }


    public string Serialize<T>(T? value) => JsonSerializer.Serialize(value, _options);
    public T? Deserialize<T>(string value) => JsonSerializer.Deserialize<T>(value, _options);
}
