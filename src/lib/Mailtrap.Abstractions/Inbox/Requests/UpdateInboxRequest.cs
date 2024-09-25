// -----------------------------------------------------------------------
// <copyright file="UpdateInboxRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Inbox.Requests;


// TODO: add validation

/// <summary>
/// Request object for inbox update operation.
/// </summary>
public sealed record UpdateInboxRequest : InboxRequest<UpdateInboxRequestDetails> { }
