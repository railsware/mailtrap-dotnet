// -----------------------------------------------------------------------
// <copyright file="ResourceDeletedException.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Exceptions;


/// <summary>
/// Exception which is thrown when attempt is made to use resource that was previously deleted.
/// </summary>
public sealed class ResourceDeletedException : MailtrapApiException
{
    private const string DefaultMessage = "Resource was deleted and can't be used anymore.";


    /// <inheritdoc />
    public ResourceDeletedException(Uri resourceUri, HttpMethod httpMethod)
        : base(resourceUri, httpMethod, DefaultMessage) { }
}
