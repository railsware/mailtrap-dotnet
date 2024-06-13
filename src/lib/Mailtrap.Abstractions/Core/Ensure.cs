// -----------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core;


/// <summary>
/// A set of helper methods for input validation.
/// </summary>
public static class Ensure
{
    /// <summary>
    /// Ensures provided <paramref name="paramValue"/> is not null.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static void NotNull<T>(T paramValue, string paramName)
    {
        if (paramValue is null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    /// <summary>
    /// Ensures provided string <paramref name="paramValue"/> is not null or empty string.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static void NotNullOrEmpty(string paramValue, string paramName)
    {
        if (string.IsNullOrEmpty(paramValue))
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
