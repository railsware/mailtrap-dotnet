// -----------------------------------------------------------------------
// <copyright file="AccountAccessResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses;


internal sealed class AccountAccessResource : RestResource, IAccountAccessResource
{
    private const string UpdatePermissionsSegment = "permissions/bulk";


    public AccountAccessResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<UpdatedPermissions> UpdatePermissions(UpdatePermissionsRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var uri = ResourceUri.Append(UpdatePermissionsSegment);

        var result = await RestResourceCommandFactory
            .CreatePut<UpdatePermissionsRequest, UpdatedPermissions>(uri, request)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    public async Task<DeletedAccountAccess> Delete(CancellationToken cancellationToken = default)
        => await Delete<DeletedAccountAccess>(cancellationToken).ConfigureAwait(false);
}
