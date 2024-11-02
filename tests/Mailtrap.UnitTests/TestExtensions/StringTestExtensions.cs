// -----------------------------------------------------------------------
// <copyright file="StringTestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.TestExtensions;


internal static class StringTestExtensions
{
    internal static string Quoted(this string? source)
    {
        return string.IsNullOrEmpty(source) ? "\"\"" : $"\"{source}\"";
    }
}
