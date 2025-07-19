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
        var baseType = typeToConvert.BaseType;

        // Converted type should derived from StringEnum<> generic type
        return
            baseType?.IsGenericType == true &&
            baseType.GetGenericTypeDefinition() == _stringEnumGenericType;
    }

    /// <inheritdoc/>
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converter = (JsonConverter)Activator.CreateInstance(
            _converterGenericType.MakeGenericType(typeToConvert));

        return converter;
    }
}
