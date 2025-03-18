namespace Mailtrap.Permissions;


/// <summary>
/// Represents account permissions resource.
/// </summary>
public interface IPermissionsResource : IRestResource
{
    /// <summary>
    /// Get all resources in your account (Inboxes, Projects, Domains, Billing and Account itself)
    /// to which the API token has admin access.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Collection of resources with their permission levels.
    /// </returns>
    public Task<IList<ResourcePermissions>> GetAll(CancellationToken cancellationToken = default);
}
