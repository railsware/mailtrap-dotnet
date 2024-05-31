// -----------------------------------------------------------------------
// <copyright file="DispositionType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Attachment disposition type
/// </summary>
public record DispositionType
{
    public static readonly DispositionType Inline = new("inline");
    public static readonly DispositionType Attachment = new("attachment");


    private readonly string _value;

    private DispositionType(string value)
    {
        _value = value;
    }

    // Overriding ToString only.
    // Valid equality and HashCode implementations are provided by the record OOB functionality.
    public override string ToString() => _value;
}
