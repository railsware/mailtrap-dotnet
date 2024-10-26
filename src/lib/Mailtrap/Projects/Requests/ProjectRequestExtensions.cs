// -----------------------------------------------------------------------
// <copyright file="ProjectRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


internal static class ProjectRequestExtensions
{
    public static CreateProjectRequestDto ToDto(this CreateProjectRequest request)
    {
        return new CreateProjectRequestDto
        {
            Project = request
        };
    }

    public static UpdateProjectRequestDto ToDto(this UpdateProjectRequest request)
    {
        return new UpdateProjectRequestDto
        {
            Project = request
        };
    }
}
