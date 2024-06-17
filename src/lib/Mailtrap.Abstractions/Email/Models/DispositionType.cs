// -----------------------------------------------------------------------
// <copyright file="DispositionType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// Attachment disposition type.
/// </summary>
[JsonConverter(typeof(DispositionTypeJsonConverter))]
public record DispositionType
{
    /// <summary>
    /// Results in the attached file displayed automatically within the message.
    /// </summary>
    public static DispositionType Inline { get; } = new(DispositionTypeNames.Inline);

    /// <summary>
    /// Results in the attached file require some action to be taken before it is displayed,
    /// such as opening or downloading the file.
    /// </summary>
    public static DispositionType Attachment { get; } = new(DispositionTypeNames.Attachment);


    private readonly string _value;

    private DispositionType(string value)
    {
        _value = value;
    }

    // Overriding ToString only.
    // Valid equality and HashCode implementations are provided by the record OOB functionality.
    /// <inheritdoc />
    public override string ToString() => _value;
}
