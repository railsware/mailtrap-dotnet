namespace Mailtrap.Projects.Requests;


/// <summary>
/// Request object for creating project.
/// </summary>
public sealed record CreateProjectRequest : ProjectRequest
{
    /// <inheritdoc />
    public CreateProjectRequest(string name) : base(name) { }
}
