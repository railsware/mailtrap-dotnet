namespace Mailtrap.ContactEvents.Requests;

/// <summary>
/// Request object for creating a contacts event.
/// </summary>
public sealed record CreateContactsEventRequest : IValidatable
{
    /// <summary>
    /// Gets contacts event name.
    /// </summary>
    ///
    /// <value>
    /// Contacts event name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Gets Contacts event params.
    /// </summary>
    ///
    /// <remarks>
    /// <inheritdoc cref="CreateContactsEventRequest" path="/param[@name=name]"/>.
    /// </remarks>
    ///
    /// <value>
    /// Contacts event params.
    /// </value>
    [JsonPropertyName("params")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, object?> Params { get; } = new Dictionary<string, object?>();

    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="name">
    /// Contact event name.
    /// </param>
    ///
    /// <param name="parameters">
    /// Contacts event parameters.
    /// </param>
    ///
    /// <remarks>
    /// <paramref name="name"/> must be 1-255 characters long.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public CreateContactsEventRequest(string name, IDictionary<string, object?>? parameters = null)
    {
        Ensure.NotNullOrEmpty(name, nameof(name));

        Name = name;

        if (parameters is not null)
        {
            // Defensive copy to prevent post-ctor mutation.
            Params = parameters is Dictionary<string, object?> dict
                        ? new Dictionary<string, object?>(dict)         // defensive copy when already a Dictionary<TKey, TValue>
                        : new Dictionary<string, object?>(parameters);  // otherwise enumerate once
        }
    }

    /// <summary>
    /// Parameterless constructor for serializers.
    /// </summary>
    [JsonConstructor]
    public CreateContactsEventRequest()
    {
        Name = string.Empty;
    }

    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return CreateContactsEventRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
