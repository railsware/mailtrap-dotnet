// -----------------------------------------------------------------------
// <copyright file="ExceptionHelpers.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Helpers;


public static class Ensure
{
    public static void NotNull<T>(T paramValue, string paramName)
    {
        if (paramValue == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    public static void NotNullOrEmpty(string paramValue, string paramName)
    {
        if (string.IsNullOrEmpty(paramValue))
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
