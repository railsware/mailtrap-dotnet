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
