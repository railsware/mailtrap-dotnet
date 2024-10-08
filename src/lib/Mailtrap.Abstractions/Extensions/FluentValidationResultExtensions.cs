// -----------------------------------------------------------------------
// <copyright file="FluentValidationResultExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using FluentValidationResult = FluentValidation.Results.ValidationResult;


namespace Mailtrap.Extensions;


/// <exclude />
/// 
/// <summary>
/// A set of helpers for <see cref="FluentValidationResult"/>.
/// </summary>
public static class FluentValidationResultExtensions
{
    /// <summary>
    /// Converts provided <see cref="FluentValidationResult"/> instance
    /// to the <see cref="ValidationResult"/>.
    /// </summary>
    /// 
    /// <param name="validationResult">
    /// <see cref="FluentValidationResult"/> instance to convert.
    /// </param>
    ///
    /// <returns>
    /// <see cref="ValidationResult"/> created from the provided <paramref name="validationResult"/>.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="validationResult"/> is <see langword="null"/>.
    /// </exception>
    public static ValidationResult ToMailtrapValidationResult(this FluentValidationResult validationResult)
    {
        Ensure.NotNull(validationResult, nameof(validationResult));

        var errors = validationResult.Errors.Select(e => e.ToString());

        return new ValidationResult(errors);
    }
}
