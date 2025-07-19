namespace Mailtrap.Permissions;


internal sealed class PermissionsResource : RestResource, IPermissionsResource
{
    private const string ResourcesSegment = "resources";


    public PermissionsResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<ResourcePermissions>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<ResourcePermissions>(ResourceUri.Append(ResourcesSegment), cancellationToken).ConfigureAwait(false);
}
