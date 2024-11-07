// -----------------------------------------------------------------------
// <copyright file="DispositionType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Represents attachment disposition type.
/// </summary>
public sealed record DispositionType : StringEnum<DispositionType>
{
    /// <summary>
    /// Gets disposition type that results in the attached file displayed automatically within the message.
    /// </summary>
    /// 
    /// <value>
    /// Static instance that results in the attached file displayed automatically within the message.
    /// </value>
    public static DispositionType Inline { get; } = Define(DispositionTypeNames.Inline);

    /// <summary>
    /// Gets disposition type that results in the attached file require some action to be taken before it is displayed,
    /// such as opening or downloading the file.
    /// </summary>
    ///
    /// <value>
    /// Static instance that results in the attached file require some action to be taken before it is displayed.
    /// </value>
    public static DispositionType Attachment { get; } = Define(DispositionTypeNames.Attachment);
}
