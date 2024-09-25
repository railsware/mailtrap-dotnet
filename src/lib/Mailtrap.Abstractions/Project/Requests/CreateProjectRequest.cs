// -----------------------------------------------------------------------
// <copyright file="CreateProjectRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Project.Requests;


// TODO: Add validation

/// <summary>
/// Request object for creating project.
/// </summary>
public sealed record CreateProjectRequest : ProjectRequest<CreateProjectRequestDetails> { }
