namespace Mailtrap.EmailCampaigns.Models;


/// <summary>
/// How an email campaign is delivered.
/// </summary>
public sealed record DeliveryMode : StringEnum<DeliveryMode>
{
    /// <summary>
    /// Gets the value representing "rapid" delivery mode.
    /// </summary>
    ///
    /// <value>
    /// Represents "rapid" delivery mode - the campaign is sent as fast as possible.
    /// </value>
    public static readonly DeliveryMode Rapid = Define("rapid");

    /// <summary>
    /// Gets the value representing "gradual" delivery mode.
    /// </summary>
    ///
    /// <value>
    /// Represents "gradual" delivery mode - sending is throttled to
    /// <see cref="EmailCampaignDeliveryOptions.EmailsPerHour"/>.
    /// </value>
    public static readonly DeliveryMode Gradual = Define("gradual");
}
