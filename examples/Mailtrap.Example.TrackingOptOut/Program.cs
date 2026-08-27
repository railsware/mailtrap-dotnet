using Mailtrap;
using Mailtrap.TrackingOptOuts;
using Mailtrap.TrackingOptOuts.Models;
using Mailtrap.TrackingOptOuts.Requests;
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
    // Get resource for tracking opt-outs collection
    ITrackingOptOutCollectionResource trackingOptOutsResource = mailtrapClient.TrackingOptOuts();

    var createRequest = new CreateTrackingOptOutRequest
    {
        Email = "test@demomailtrap.co",
        DomainId = 12345
    };

    TrackingOptOut createdTrackingOptOut = await trackingOptOutsResource.Create(createRequest);

    logger.LogInformation("Created tracking opt-out: {TrackingOptOut}", createdTrackingOptOut);

    var filter = new TrackingOptOutFilter
    {
        Email = "test@demomailtrap.co",
        StartTime = DateTimeOffset.UtcNow.AddDays(-7),
        EndTime = DateTimeOffset.UtcNow
    };

    TrackingOptOutList trackingOptOuts = await trackingOptOutsResource.Fetch(filter);

    logger.LogInformation(
        "Fetched {Count} tracking opt-out(s), cursor for the next page: {LastId}",
        trackingOptOuts.Items.Count,
        trackingOptOuts.LastId);

    // Get resource for specific tracking opt-out
    ITrackingOptOutResource trackingOptOutResource = mailtrapClient.TrackingOptOut(createdTrackingOptOut.Id);

    // Delete the tracking opt-out
    TrackingOptOut deletedTrackingOptOut = await trackingOptOutResource.Delete();

    logger.LogInformation("Deleted tracking opt-out: {TrackingOptOut}", deletedTrackingOptOut);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.ExitCode = 1;
    return;
}
