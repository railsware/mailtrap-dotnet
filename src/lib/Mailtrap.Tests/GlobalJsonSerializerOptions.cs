// -----------------------------------------------------------------------
// <copyright file="GlobalJsonSerializerOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests;


internal static class GlobalJsonSerializerOptions
{
    public static JsonSerializerOptions NotIndented { get; }
        = MailtrapApiClientSerializationOptions.Default.ToJsonSerializerOptions();
}
