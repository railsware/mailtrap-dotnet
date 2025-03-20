namespace Mailtrap.Core.Validation;


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
