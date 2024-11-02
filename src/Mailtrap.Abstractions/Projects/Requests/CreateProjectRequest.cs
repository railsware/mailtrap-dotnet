// -----------------------------------------------------------------------
// <copyright file="CreateProjectRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


/// <summary>
/// Request object for creating project.
/// </summary>
public sealed record CreateProjectRequest : ProjectRequest
{
    /// <inheritdoc />
    public CreateProjectRequest(string name) : base(name) { }
}
