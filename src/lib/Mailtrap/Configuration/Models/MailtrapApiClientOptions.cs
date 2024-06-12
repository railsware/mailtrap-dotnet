// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public record MailtrapApiClientOptions
{
    public static MailtrapApiClientOptions Default { get; } = new();

    public MailtrapApiClientEndpointOptions SendEndpoint { get; set; } = new MailtrapApiClientEndpointOptions(ApiEndpoints.SendDefaultUrl);
    public MailtrapApiClientEndpointOptions TestEndpoint { get; set; } = new MailtrapApiClientEndpointOptions(ApiEndpoints.TestDefaultUrl);
    public MailtrapApiClientEndpointOptions BulkEndpoint { get; set; } = new MailtrapApiClientEndpointOptions(ApiEndpoints.BulkDefaultUrl);

    public MailtrapApiClientAuthenticationOptions Authentication { get; set; } = MailtrapApiClientAuthenticationOptions.Empty;

    public MailtrapApiClientSerializationOptions Serialization { get; set; } = MailtrapApiClientSerializationOptions.Default;
}
