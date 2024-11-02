// -----------------------------------------------------------------------
// <copyright file="SendingDomainRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Requests;


internal static class SendingDomainRequestExtensions
{
    public static CreateSendingDomainRequestDto ToDto(this CreateSendingDomainRequest request)
    {
        return new CreateSendingDomainRequestDto
        {
            Domain = request
        };
    }

    public static IList<SendingDomain> FromDto(this GetAllSendingDomainResponseDto response)
    {
        return response.Domains;
    }
}
