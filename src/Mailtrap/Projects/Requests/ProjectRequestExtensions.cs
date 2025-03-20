namespace Mailtrap.Projects.Requests;


internal static class ProjectRequestExtensions
{
    public static CreateProjectRequestDto ToDto(this CreateProjectRequest request) => new(request);

    public static UpdateProjectRequestDto ToDto(this UpdateProjectRequest request) => new(request);
}
