// -----------------------------------------------------------------------
// <copyright file="MessageId.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// Represents MessageId value returned from the API.
/// </summary>
[JsonConverter(typeof(MessageIdJsonConverter))]
public record MessageId
{
    /// <summary>
    /// Returns empty <see cref="MessageId"/> object.
    /// </summary>
    public static MessageId Empty { get; } = new(string.Empty);


    private readonly string _value;

    /// <summary>
    /// Returns <see langword="true"/> if this <see cref="MessageId"/> object is empty,
    /// <see langword="false"/> otherwise.
    /// </summary>
    public bool IsEmpty => string.IsNullOrEmpty(_value);


    /// <summary>
    /// Construct a <see cref="MessageId"/> from the specified string value.
    /// </summary>
    /// <param name="value">The string value that represents a MessageId.</param>
    public MessageId(string value)
    {
        Ensure.NotNull(value, nameof(value));

        _value = value;
    }


    /// <inheritdoc/>
    public override string ToString() => _value;

    /// <inheritdoc/>
    public override int GetHashCode() => _value.GetHashCode();

    /// <inheritdoc/>
    public virtual bool Equals(MessageId? other)
        => string.Equals(_value, other?._value, StringComparison.OrdinalIgnoreCase);
}
