// -----------------------------------------------------------------------
// <copyright file="StringEnum.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Runtime.CompilerServices;


namespace Mailtrap.Models;


/// <summary>
/// Generic string enum implementation.
/// </summary>
[SuppressMessage("Design", "CA1000:Do not declare static members on generic types")]
[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix")]
public abstract record StringEnum<T> where T : StringEnum<T>, new()
{
    private static readonly ConcurrentDictionary<string, T> s_values = new();


    /// <summary>
    /// Represents empty enum value.
    /// </summary>
    public static T None { get; } = Define(string.Empty);

    /// <summary>
    /// Represents unknown enum value.
    /// </summary>
    public static T Unknown { get; } = Define(nameof(Unknown));


    static StringEnum()
    {
        // Explicitly initialize static fields in derived enum type upon type initialization.
        // This will ensure that s_values dictionary is populated with all valid enum entries.
        RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);

        s_values.TryAdd(None._value, None);
        s_values.TryAdd(Unknown._value, Unknown);
    }

    /// <summary>
    /// Finds enum entry by the specified string value.
    /// </summary>
    /// 
    /// <param name="value">
    /// String value to find enum entry for.
    /// </param>
    /// 
    /// <returns>
    /// Enum entry for the specified string value if found, <see langword="null"/> otherwise.
    /// </returns>
    ///
    /// <remarks>
    /// Search is case-sensitive.
    /// </remarks>    
    public static T Find(string? value)
    {
        return
            string.IsNullOrEmpty(value) ? None :
            s_values.TryGetValue(value!, out var result) ? result :
            Unknown;
    }


    /// <summary>
    /// Defines new enum entry and adds it to the values dictionary.
    /// </summary>
    /// 
    /// <param name="value">
    /// Enum entry value.
    /// </param>
    protected static T Define(string value)
    {
        Ensure.NotNull(value, nameof(value));

        var enumValue = new T { _value = value };

        var added = s_values.TryAdd(value, enumValue);

        return added
            ? enumValue
            : throw new ArgumentException($"Attempt to define a duplicate value '{value}' in '{typeof(T).Name}'.", nameof(value));
    }


    private string _value = string.Empty;


    /// <inheritdoc />
    public sealed override string ToString() => _value;

    /// <inheritdoc />
    public override int GetHashCode() => _value.GetHashCode();

    // We can safely do a reference comparison here, because we know that all enum values are singletons.
    /// <inheritdoc />
    public virtual bool Equals(T? other) => ReferenceEquals(this, other);
}
