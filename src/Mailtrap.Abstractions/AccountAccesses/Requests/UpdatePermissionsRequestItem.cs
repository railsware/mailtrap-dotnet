namespace Mailtrap.AccountAccesses.Requests;


/// <summary>
/// Represents permissions details for account access update request.
/// </summary>
public sealed record UpdatePermissionsRequestItem : IValidatable
{
    /// <summary>
    /// Gets the resource identifier.
    /// </summary>
    ///
    /// <value>
    /// Resource identifier.
    /// </value>
    [JsonPropertyName("resource_id")]
    [JsonPropertyOrder(1)]
    public long ResourceId { get; }

    /// <summary>
    /// Gets the resource type.
    /// </summary>
    ///
    /// <value>
    /// Resource type.
    /// </value>
    [JsonPropertyName("resource_type")]
    [JsonPropertyOrder(2)]
    public ResourceType ResourceType { get; }

    /// <summary>
    /// Gets the resource access level.
    /// </summary>
    ///
    /// <value>
    /// Access level for resource.
    /// </value>
    ///
    /// <remarks>
    /// Allowed values: <see cref="AccessLevel.Viewer"/> or <see cref="AccessLevel.Admin"/>
    /// </remarks>
    [JsonPropertyName("access_level")]
    [JsonPropertyOrder(3)]
    public AccessLevel AccessLevel { get; }

    /// <summary>
    /// Gets the flag indicating whether to revoke resource permissions.<br />
    /// If set to <see langword="true"/> will completely revoke access permissions from the resource, instead of update.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> means a revocation of access permissions from the resource, instead of updating them.
    /// </value>
    ///
    /// <remarks>
    /// Has a priority over <see cref="AccessLevel"/>.<br />
    /// If set to <see langword="true"/>, the <see cref="AccessLevel"/> value will be ignored.
    /// </remarks>
    [JsonPropertyName("_destroy")]
    [JsonPropertyOrder(4)]
    public bool Revoke { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    /// 
    /// <param name="resourceId">
    /// ID of the resource to update permissions for.
    /// </param>
    /// 
    /// <param name="resourceType">
    /// Type of the resource to update permissions for.
    /// </param>
    /// 
    /// <param name="accessLevel">
    /// <para>
    /// Target access level for the resource.
    /// </para>
    /// <para>
    /// Allowed values: <see cref="AccessLevel.Viewer"/> or <see cref="AccessLevel.Admin"/>
    /// </para>
    /// </param>
    /// 
    /// <param name="revokePermissions">
    /// If set to <see langword="true"/> will completely revoke access permissions from the resource, instead of update.
    /// </param>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="resourceType"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="resourceId"/> is less than or equal to zero.
    /// </exception>
    public UpdatePermissionsRequestItem(
        long resourceId,
        ResourceType resourceType,
        AccessLevel accessLevel,
        bool revokePermissions = false)
    {
        Ensure.GreaterThanZero(resourceId, nameof(resourceId));
        Ensure.NotNull(resourceType, nameof(resourceType));

        if (ResourceType.None.Equals(resourceType))
        {
            throw new ArgumentException(
                "'None' cannot be used as resource type for update permissions request.",
                nameof(resourceType));
        }

        if (accessLevel is not AccessLevel.Viewer and not AccessLevel.Admin)
        {
            throw new ArgumentOutOfRangeException(
                nameof(accessLevel),
                accessLevel,
                "Allowed values are Viewer or Admin");
        }

        ResourceId = resourceId;
        ResourceType = resourceType;
        AccessLevel = accessLevel;
        Revoke = revokePermissions;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return UpdatePermissionsRequestItemValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
