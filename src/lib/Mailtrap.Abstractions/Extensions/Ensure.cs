// -----------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


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
    public static void NotNull<T>(T paramValue, string paramName, string? message = default)
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
    public static void NotNullOrEmpty(string paramValue, string paramName, string? message = default)
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
}
