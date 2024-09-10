// -----------------------------------------------------------------------
// <copyright file="DispositionType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// Represents attachment disposition type.
/// </summary>
[JsonConverter(typeof(DispositionTypeJsonConverter))]
public sealed record DispositionType
{
    /// <summary>
    /// Gets disposition type that results in the attached file displayed automatically within the message.
    /// </summary>
    /// 
    /// <value>
    /// Static instance, when used results in the attached file displayed automatically within the message.
    /// </value>
    public static DispositionType Inline { get; } = new(DispositionTypeNames.Inline);

    /// <summary>
    /// Gets disposition type that results in the attached file require some action to be taken before it is displayed,
    /// such as opening or downloading the file.
    /// </summary>
    ///
    /// <value>
    /// Static instance, when used results in the attached file require some action to be taken before it is displayed.
    /// </value>
    public static DispositionType Attachment { get; } = new(DispositionTypeNames.Attachment);


    private readonly string _value;

    private DispositionType(string value)
    {
        _value = value;
    }


    // Overriding ToString only.
    // Valid equality and HashCode implementations are provided by the record OOB functionality.
    /// <inheritdoc />
    ///
    /// <returns>
    /// String representation of the disposition type.
    /// </returns>
    public override string ToString() => _value;
}
