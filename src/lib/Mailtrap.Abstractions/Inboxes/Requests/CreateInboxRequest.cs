// -----------------------------------------------------------------------
// <copyright file="CreateInboxRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


// TODO: add validation

/// <summary>
/// Request object for inbox create operation.
/// </summary>
public sealed record CreateInboxRequest : InboxRequest<CreateInboxRequestDetails>
{
    /// <summary>
    /// Gets or sets project identifier for inbox creation.
    /// </summary>
    ///
    /// <value>
    /// Project identifier for inbox creation.
    /// </value>
    [JsonIgnore]
    public long ProjectId { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="projectId">
    /// ID of the project to create inbox for.
    /// </param>
    public CreateInboxRequest(long projectId)
    {
        ProjectId = projectId;
    }
}
