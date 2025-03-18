namespace Mailtrap.Inboxes.Requests;


/// <summary>
/// Request object for inbox create operation.
/// </summary>
public sealed record CreateInboxRequest : InboxRequest
{
    /// <summary>
    /// Gets project identifier for inbox creation.
    /// </summary>
    ///
    /// <value>
    /// Project identifier for inbox creation.
    /// </value>
    [JsonIgnore]
    public long ProjectId { get; }

    /// <summary>
    /// Gets inbox name.
    /// </summary>
    /// 
    /// <value>
    /// Inbox name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string Name { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="projectId">
    /// ID of the project to create inbox for.
    /// </param>
    /// 
    /// <param name="name">
    /// Name of the inbox to create.
    /// </param>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public CreateInboxRequest(long projectId, string name)
    {
        Ensure.NotNullOrEmpty(name, nameof(name));

        ProjectId = projectId;
        Name = name;
    }
}
