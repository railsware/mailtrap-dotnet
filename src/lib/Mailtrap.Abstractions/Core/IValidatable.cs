// -----------------------------------------------------------------------
// <copyright file="IValidatable.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core;


/// <summary>
/// Defines validatable object.
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Validates current instance and throws <see cref="ArgumentException"/>
    /// in case of any validation errors.
    /// </summary>
    /// 
    /// <exception cref="ArgumentException">
    /// When validation fails.
    /// </exception>
    public void Validate();

    /// <summary>
    /// Allows to check if current instance is valid.
    /// </summary>
    /// 
    /// <returns>
    /// <see langword="true"/> if current instance is valid.<br />
    /// <see langword="false"/> otherwise.
    /// </returns>
    public bool IsValid();
}
