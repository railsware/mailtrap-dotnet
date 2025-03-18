namespace Mailtrap.Accounts;


internal sealed class AccountCollectionResource : RestResource, IAccountCollectionResource
{
    public AccountCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<Account>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<Account>(cancellationToken).ConfigureAwait(false);
}
