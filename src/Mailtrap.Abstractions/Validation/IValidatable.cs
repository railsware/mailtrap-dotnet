// -----------------------------------------------------------------------
// <copyright file="IValidatable.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Validation;


/// <summary>
/// Defines a validatable object.
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Validates the current instance.
    /// </summary>
    ///
    /// <returns>
    /// Object containing validation errors, if any.
    /// </returns>
    public ValidationResult Validate();
}
