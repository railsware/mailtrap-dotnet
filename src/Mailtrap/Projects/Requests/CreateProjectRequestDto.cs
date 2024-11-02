// -----------------------------------------------------------------------
// <copyright file="CreateProjectRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


/// <summary>
/// Request object for creating project.
/// </summary>
internal sealed record CreateProjectRequestDto : ProjectRequestDto<CreateProjectRequest>
{
    public CreateProjectRequestDto(CreateProjectRequest project) : base(project) { }
}
