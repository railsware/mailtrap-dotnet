// -----------------------------------------------------------------------
// <copyright file="Reactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Example.ApiUsage.Logic;


internal abstract class Reactor
{
    protected readonly IMailtrapClient _mailtrapClient;
    protected readonly ILogger<Reactor> _logger;


    protected Reactor(IMailtrapClient mailtrapClient, ILogger<Reactor> logger)
    {
        _mailtrapClient = mailtrapClient;
        _logger = logger;
    }
}
