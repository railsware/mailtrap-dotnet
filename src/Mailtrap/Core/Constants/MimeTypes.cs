// -----------------------------------------------------------------------
// <copyright file="MimeTypes.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Constants;


internal static class MimeTypes
{
    internal static class Application
    {
        internal const string Root = "application";

        internal const string Json = $"{Root}/json";
    }

    internal static class Message
    {
        internal const string Root = "message";

        internal const string Eml = $"{Root}/rfc822";
    }
}
