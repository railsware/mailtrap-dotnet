namespace Mailtrap.Projects.Requests;


/// <summary>
/// Request object for updating project details.
/// </summary>
internal sealed record UpdateProjectRequestDto : ProjectRequestDto<UpdateProjectRequest>
{
    public UpdateProjectRequestDto(UpdateProjectRequest project) : base(project) { }
}
