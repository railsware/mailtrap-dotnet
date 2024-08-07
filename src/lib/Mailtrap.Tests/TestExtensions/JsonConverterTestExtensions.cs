// -----------------------------------------------------------------------
// <copyright file="JsonConverterTestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.TestExtensions;


internal static class JsonConverterTestExtensions
{
    internal static TResult? Read<TResult>(
        this JsonConverter<TResult> converter,
        string token,
        JsonSerializerOptions? options = default)
    {
        options ??= JsonSerializerOptions.Default;

        var bytes = Encoding.UTF8.GetBytes(token);

        var reader = new Utf8JsonReader(bytes);

        reader.Read();

        var result = converter.Read(ref reader, typeof(TResult), options);

        return result;
    }

    internal static string Write<T>(
        this JsonConverter<T> converter,
        T value,
        JsonSerializerOptions? options = default)
    {
        options ??= JsonSerializerOptions.Default;

        using var ms = new MemoryStream();

        using var writer = new Utf8JsonWriter(ms);

        converter.Write(writer, value, options);

        writer.Flush();

        var result = Encoding.UTF8.GetString(ms.ToArray());

        return result;
    }
}

