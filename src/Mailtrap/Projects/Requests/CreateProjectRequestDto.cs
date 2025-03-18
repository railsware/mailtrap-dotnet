namespace Mailtrap.Projects.Requests;


/// <summary>
/// Request object for creating project.
/// </summary>
internal sealed record CreateProjectRequestDto : ProjectRequestDto<CreateProjectRequest>
{
    public CreateProjectRequestDto(CreateProjectRequest project) : base(project) { }
}
