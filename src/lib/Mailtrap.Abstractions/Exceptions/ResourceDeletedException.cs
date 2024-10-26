// -----------------------------------------------------------------------
// <copyright file="ResourceDeletedException.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Exceptions;


/// <summary>
/// Exception which is thrown when attempt is made to use resource that was previously deleted.
/// </summary>
public sealed class ResourceDeletedException : MailtrapException
{
    private const string DefaultMessage = "Resource was deleted and can't be used anymore.";


    /// <summary>
    /// Gets resource URI that caused exception.
    /// </summary>
    ///
    /// <value>
    /// Resource URI that caused exception.
    /// </value>
    public Uri ResourceUri { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceDeletedException"/> with message
    /// that contains deleted resource URI, defined by <paramref name="resourceUri"/>.
    /// </summary>
    ///
    /// <param name="resourceUri">
    /// Resource URI that caused exception.
    /// </param>
    ///
    /// <exception cref="ArgumentNullException">
    /// When the <paramref name="resourceUri"/> is <see langword="null"/>.
    /// </exception>
    public ResourceDeletedException(Uri resourceUri) : base(DefaultMessage)
    {
        Ensure.NotNull(resourceUri, nameof(resourceUri));

        ResourceUri = resourceUri;
    }
}
