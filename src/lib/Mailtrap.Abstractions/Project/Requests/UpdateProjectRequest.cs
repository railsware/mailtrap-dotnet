// -----------------------------------------------------------------------
// <copyright file="UpdateProjectRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Project.Requests;


// TODO: Add validation

/// <summary>
/// Request object for updating project details.
/// </summary>
public sealed record UpdateProjectRequest : ProjectRequest<UpdateProjectRequestDetails> { }
