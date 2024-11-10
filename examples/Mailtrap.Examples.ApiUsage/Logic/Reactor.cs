// -----------------------------------------------------------------------
// <copyright file="Reactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Examples.ApiUsage.Logic;


internal abstract class Reactor
{
    protected readonly IMailtrapClient _mailtrapClient;
    protected readonly ILogger<AccountReactor> _logger;


    protected Reactor(IMailtrapClient mailtrapClient, ILogger<AccountReactor> logger)
    {
        _mailtrapClient = mailtrapClient;
        _logger = logger;
    }
}
