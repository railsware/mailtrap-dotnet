// -----------------------------------------------------------------------
// <copyright file="ProjectRequestDto.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


/// <summary>
/// Generic request object for project CRUD operations.
/// </summary>
internal record ProjectRequestDto<T> : IValidatable
    where T : ProjectRequest
{
    /// <summary>
    /// Gets or sets project request payload.
    /// </summary>
    ///
    /// <value>
    /// Project request payload.
    /// </value>
    [JsonPropertyName("project")]
    [JsonPropertyOrder(1)]
    public T Project { get; }


    public ProjectRequestDto(T project)
    {
        Ensure.NotNull(project, nameof(project));

        Project = project;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ProjectRequestValidator.Instance
            .Validate(Project)
            .ToMailtrapValidationResult();
    }
}
