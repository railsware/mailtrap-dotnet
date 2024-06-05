// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public record MailtrapApiClientOptions
{
    public static MailtrapApiClientOptions Default { get; } = new();

    public SendEndpointOptions SendEndpoint { get; set; } = SendEndpointOptions.Default;
    public TestEndpointOptions TestEndpoint { get; set; } = TestEndpointOptions.Default;
    public BulkEndpointOptions BulkEndpoint { get; set; } = BulkEndpointOptions.Default;

    public MailtrapApiClientAuthenticationOptions Authentication { get; set; } = MailtrapApiClientAuthenticationOptions.Default;

    public MailtrapApiClientSerializationOptions Serialization { get; set; } = MailtrapApiClientSerializationOptions.Default;
}
