namespace Mailtrap.Inbound.Models;


/// <summary>
/// Direction of a message within a thread.
/// </summary>
public sealed record ThreadMessageDirection : StringEnum<ThreadMessageDirection>
{
    /// <summary>
    /// A received (inbound) message.
    /// </summary>
    public static readonly ThreadMessageDirection Inbound = Define("inbound");

    /// <summary>
    /// A sent (outbound) message - a reply, reply-all, or forward.
    /// </summary>
    public static readonly ThreadMessageDirection Outbound = Define("outbound");
}
