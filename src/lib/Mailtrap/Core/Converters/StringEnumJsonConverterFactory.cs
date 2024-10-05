// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Converters;


/// <summary>
/// Custom JSON converter factory to be used for <see cref="StringEnum{T}"/>.
/// </summary>
internal sealed class StringEnumJsonConverterFactory : JsonConverterFactory
{
    private readonly Type _stringEnumGenericType = typeof(StringEnum<>);
    private readonly Type _converterGenericType = typeof(StringEnumJsonConverter<>);


    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
        return _stringEnumGenericType.IsAssignableFrom(typeToConvert);
    }

    /// <inheritdoc/>
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converter = (JsonConverter)Activator.CreateInstance(
            _converterGenericType.MakeGenericType(typeToConvert),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: [options],
            culture: null);

        return converter;
    }
}
