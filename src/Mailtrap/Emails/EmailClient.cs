// -----------------------------------------------------------------------
// <copyright file="EmailClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails;


/// <summary>
/// <see cref="IEmailClient"/> implementation.
/// </summary>
internal sealed class EmailClient : RestResource, IEmailClient
{
    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public EmailClient(IRestResourceCommandFactory restResourceCommandFactory, Uri sendUri)
        : base(restResourceCommandFactory, sendUri) { }


    /// <inheritdoc/>
    public async Task<SendEmailResponse> Send(SendEmailRequest request, CancellationToken cancellationToken = default)
        => await Create<SendEmailRequest, SendEmailResponse>(request, cancellationToken).ConfigureAwait(false);
}
