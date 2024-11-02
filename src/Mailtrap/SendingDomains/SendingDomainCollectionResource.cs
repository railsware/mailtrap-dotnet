// -----------------------------------------------------------------------
// <copyright file="SendingDomainCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains;


internal sealed class SendingDomainCollectionResource : RestResource, ISendingDomainCollectionResource
{
    public SendingDomainCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<SendingDomain>> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await Get<GetAllSendingDomainResponseDto>(cancellationToken).ConfigureAwait(false);

        return result.FromDto();
    }

    public async Task<SendingDomain> Create(CreateSendingDomainRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateSendingDomainRequestDto, SendingDomain>(request.ToDto(), cancellationToken).ConfigureAwait(false);
}
