// -----------------------------------------------------------------------
// <copyright file="SendingDomain.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Extensions.DependencyInjection;
using Mailtrap.Projects;
using Mailtrap.Projects.Models;
using Mailtrap.Projects.Requests;
using Mailtrap.Projects.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

hostBuilder.Services.AddMailtrapClient(config);

using IHost host = hostBuilder.Build();

ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();
IMailtrapClient mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

try
{
    var accountId = 12345;
    IAccountResource accountResource = mailtrapClient.Account(accountId);

    var projectName = "My Test Project";

    // Get resource for projects collection
    IProjectCollectionResource projectsResource = accountResource.Projects();

    // Get all projects for account
    IList<Project> projects = await projectsResource.GetAll();

    Project? project = projects
        .FirstOrDefault(p => string.Equals(p.Name, projectName, StringComparison.OrdinalIgnoreCase));

    if (project is null)
    {
        logger.LogWarning("No project found. Creating.");

        // Create project
        var createProjectRequest = new CreateProjectRequest(projectName);
        project = await projectsResource.Create(createProjectRequest);
    }
    else
    {
        logger.LogInformation("Project found.");
    }

    // Get resource for specific project
    IProjectResource projectResource = accountResource.Project(project.Id);

    // Get details
    project = await projectResource.GetDetails();
    logger.LogInformation("Project: {Project}", project);

    // Update project details
    var updateProjectRequest = new UpdateProjectRequest("Updated Project Name");
    Project updatedProject = await projectResource.Update(updateProjectRequest);
    logger.LogInformation("Updated Project: {Project}", updatedProject);

    // Delete project
    // Beware that project resource becomes invalid after deletion and should not be used anymore
    DeleteProjectResponse deletedProject = await projectResource.Delete();
    logger.LogInformation("Deleted Project: {Project}", deletedProject);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.FailFast(ex.Message);
    throw;
}
