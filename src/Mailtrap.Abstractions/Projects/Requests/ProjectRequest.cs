// -----------------------------------------------------------------------
// <copyright file="ProjectRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Requests;


/// <summary>
/// Generic request object for project CRUD operations.
/// </summary>
public record ProjectRequest : IValidatable
{
    /// <summary>
    /// Gets project name.
    /// </summary>
    ///
    /// <value>
    /// Project name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string Name { get; }

    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="name">
    /// Name of the project.
    /// </param>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public ProjectRequest(string name)
    {
        Ensure.NotNullOrEmpty(name, nameof(name));

        Name = name;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ProjectRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
