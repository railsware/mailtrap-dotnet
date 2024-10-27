// -----------------------------------------------------------------------
// <copyright file="ProjectRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Validators;


/// <summary>
/// 
/// </summary>
public sealed class ProjectRequestValidator : AbstractValidator<ProjectRequest>
{
    /// <summary>
    /// 
    /// </summary>
    public static ProjectRequestValidator Instance { get; } = new();

    /// <summary>
    /// 
    /// </summary>
    public ProjectRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().Length(2, 100);
    }
}
