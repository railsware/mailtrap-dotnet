// -----------------------------------------------------------------------
// <copyright file="ExceptionHelpers.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Helpers;


public static class ExceptionHelpers
{
    public static void ThrowIfNull<T>(T paramValue, string paramName)
    {
        if (paramValue == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    public static void ThrowIfNullOrEmpty(string paramValue, string paramName)
    {
        if (string.IsNullOrEmpty(paramValue))
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
