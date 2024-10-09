// -----------------------------------------------------------------------
// <copyright file="UpdateInboxRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


/// <summary>
/// Request object for inbox update operation.
/// </summary>
internal sealed record UpdateInboxRequestDto : InboxRequestDto<UpdateInboxRequest> { }
