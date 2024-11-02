// -----------------------------------------------------------------------
// <copyright file="CreateInboxRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


/// <summary>
/// Request object for inbox create operation.
/// </summary>
internal sealed record CreateInboxRequestDto : InboxRequestDto<CreateInboxRequest> { }
