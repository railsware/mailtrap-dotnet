// -----------------------------------------------------------------------
// <copyright file="ValidationResultExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


/// <exclude/>
/// 
/// <summary>
/// A set of helpers for <see cref="ValidationResult"/>.
/// </summary>
public static class ValidationResultExtensions
{
    /// <summary>
    /// Ensures that provided <see cref="ValidationResult"/> instance is valid
    /// and throws an exception, containing validation errors summary, if not.
    /// </summary>
    /// 
    /// <param name="validationResult">
    /// Validation result to verify.
    /// </param>
    /// 
    /// <param name="paramName"></param>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="validationResult"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref="ArgumentException">
    /// When <paramref name="validationResult"/> is not valid.
    /// </exception>
    public static void EnsureValidity(this ValidationResult validationResult, string paramName)
    {
        Ensure.NotNull(validationResult, nameof(validationResult));

        if (!validationResult.IsValid)
        {
            throw new ArgumentException($"Validation failed:\n{validationResult.ToString("\n")}", paramName);
        }
    }
}
