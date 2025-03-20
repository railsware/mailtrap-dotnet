namespace Mailtrap.Projects.Requests;


/// <summary>
/// Request object for updating project details.
/// </summary>
public sealed record UpdateProjectRequest : ProjectRequest
{
    /// <inheritdoc />
    public UpdateProjectRequest(string name) : base(name) { }
}
