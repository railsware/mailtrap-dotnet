namespace Mailtrap.Core.Extensions;


/// <exclude/>
///
/// <summary>
/// A set of helper methods for input validation.
/// </summary>
public static class Ensure
{
    /// <summary>
    /// Ensures provided <paramref name="paramValue"/> is not null.
    /// </summary>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="paramValue"/> is <see langword="null"/>.
    /// </exception>
    public static void NotNull<T>(T? paramValue, string paramName, string? message = default)
    {
        if (paramValue is not null)
        {
            return;
        }

        if (message is null)
        {
            throw new ArgumentNullException(paramName);
        }
        else
        {
            throw new ArgumentNullException(paramName, message);
        }
    }

    /// <summary>
    /// Ensures provided string <paramref name="paramValue"/> is not null or empty string.
    /// </summary>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="paramValue"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static void NotNullOrEmpty(string? paramValue, string paramName, string? message = default)
    {
        if (!string.IsNullOrEmpty(paramValue))
        {
            return;
        }

        if (message is null)
        {
            throw new ArgumentNullException(paramName);
        }
        else
        {
            throw new ArgumentNullException(paramName, message);
        }
    }

    /// <summary>
    /// Ensures provided collection <paramref name="paramValue"/> is not null or empty.
    /// </summary>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="paramValue"/> is <see langword="null"/> or empty.
    /// </exception>
    public static void NotNullOrEmpty<T>(IEnumerable<T>? paramValue, string paramName, string? message = default)
    {
        if (paramValue is not null && paramValue.Any())
        {
            return;
        }

        if (message is null)
        {
            throw new ArgumentNullException(paramName);
        }
        else
        {
            throw new ArgumentNullException(paramName, message);
        }
    }

    /// <summary>
    /// Ensures provided <paramref name="paramValue"/> is greater than zero.
    /// </summary>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="paramValue"/> is equal or less than zero.
    /// </exception>
    public static void GreaterThanZero(long paramValue, string paramName, string? message = default)
    {
        if (paramValue > 0)
        {
            return;
        }

        if (message is null)
        {
            throw new ArgumentOutOfRangeException(paramName);
        }
        else
        {
            throw new ArgumentOutOfRangeException(paramName, paramValue, message);
        }
    }
}
