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
    /// Gets empty <see cref="MessageId"/> object.
    /// </summary>
    ///
    /// <value>
    /// Static instance, representing an empty <see cref="MessageId"/> object.
    /// </value>
    public static MessageId Empty { get; } = new(string.Empty);


    private readonly string _value;

    /// <summary>
    /// Boolean flag, that indicates whether current <see cref="MessageId"/> instance is empty.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if current <see cref="MessageId"/> instance is empty.<br/>
    /// <see langword="false"/> otherwise.
    /// </value>
    public bool IsEmpty => string.IsNullOrEmpty(_value);


    /// <summary>
    /// Constructs a <see cref="MessageId"/> instance from the specified string value.
    /// </summary>
    /// 
    /// <param name="value">
    /// Value that represents ID of the message.
    /// </param>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="value"/> is <see langword="null"/>.
    /// </exception>
    public MessageId(string value)
    {
        Ensure.NotNull(value, nameof(value));

        _value = value;
    }


    /// <inheritdoc/>
    ///
    /// <returns>
    /// String representation of the current <see cref="MessageId"/> instance.
    /// </returns>
    public override string ToString() => _value;

    /// <inheritdoc/>
    ///
    /// <returns>
    /// A hash code for the current <see cref="MessageId"/> instance.
    /// </returns>
    public override int GetHashCode() => _value.GetHashCode();

    /// <inheritdoc/>
    ///
    /// <returns>
    /// <see langword="true"/> if the current <see cref="MessageId"/> instance is equal
    /// to the <paramref name="other"/> one.<br/>
    /// <see langword="false"/> otherwise.
    /// </returns>
    public virtual bool Equals(MessageId? other)
        => string.Equals(_value, other?._value, StringComparison.OrdinalIgnoreCase);
}
