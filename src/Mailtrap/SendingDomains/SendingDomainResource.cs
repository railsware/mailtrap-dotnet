// -----------------------------------------------------------------------
// <copyright file="SendingDomainResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap.SendingDomains;


internal sealed class SendingDomainResource : RestResource, ISendingDomainResource
{
    private const string SendSetupInstructionsSegment = "send_setup_instructions";


    public SendingDomainResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<SendingDomain> GetDetails(CancellationToken cancellationToken = default)
        => await Get<SendingDomain>(cancellationToken).ConfigureAwait(false);

    public async Task SendInstructions(SendingDomainInstructionsRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var uri = ResourceUri.Append(SendSetupInstructionsSegment);

        await RestResourceCommandFactory
            .CreatePostWithStatusCodeResult(uri, request)
            .Execute(cancellationToken)
            .ConfigureAwait(false);
    }
}
