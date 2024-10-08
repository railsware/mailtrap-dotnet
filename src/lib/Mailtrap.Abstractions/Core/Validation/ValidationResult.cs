// -----------------------------------------------------------------------
// <copyright file="ValidationResult.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Validation;


/// <summary>
/// Represents validation result.
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// A collection of errors.
    /// </summary>
    public IList<string> Errors { get; }

    /// <summary>
    /// Whether validation succeeded.
    /// </summary>
    public bool IsValid => Errors.Count == 0;


    /// <summary>
    /// Creates a new <see cref="ValidationResult"/> instance.
    /// </summary>
    public ValidationResult()
    {
        Errors = [];
    }

    /// <summary>
    /// Creates a new <see cref="ValidationResult"/> instance from a collection of errors.
    /// </summary>
    ///
    /// <param name="errors">
    /// Collection of errors to initialize the instance with.
    /// </param>
    public ValidationResult(IEnumerable<string> errors)
    {
        Ensure.NotNull(errors, nameof(errors));

        Errors = errors
            .Where(x => x != null)
            .ToList();
    }


    /// <summary>
    /// Ensures that the current instance is valid and throws an exception,
    /// containing validation errors summary, if not.
    /// </summary>
    /// 
    /// <param name="paramName">
    /// Name of the parameter that have been validated.
    /// </param>
    ///
    /// <exception cref="ArgumentException">
    /// When the instance represents invalid result.
    /// </exception>
    public void EnsureValidity(string paramName)
    {
        if (!IsValid)
        {
            throw new ArgumentException($"Validation failed:{Environment.NewLine}{this}", paramName);
        }
    }

    /// <summary>
    /// Generates a single <see langword="string"/>, that contains all error messages separated by default new line separator.
    /// </summary>
    /// 
    /// <returns>
    /// Single <see langword="string"/>, that contains all error messages separated by default new line separator.
    /// </returns>
    public override string ToString() => ToString(Environment.NewLine);

    /// <summary>
    /// Generates a single <see langword="string"/>, that contains all error messages separated by the specified <paramref name="separator"/>.
    /// </summary>
    ///
    /// <param name="separator">
    /// A string to separate error messages.
    /// </param>
    ///
    /// <returns>
    /// Single <see langword="string"/>, that contains all error messages separated by the specified <paramref name="separator"/>.
    /// </returns>
    public string ToString(string separator) => string.Join(separator, Errors);
}
