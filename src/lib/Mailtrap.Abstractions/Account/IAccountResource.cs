// -----------------------------------------------------------------------
// <copyright file="IAccountResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Account;


/// <summary>
/// Represents account resource.
/// </summary>
public interface IAccountResource
{
    /// <summary>
    /// Gets billing resource for the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Billing resource for the account, represented by this resource instance.
    /// </returns>
    public IBillingResource Billing();

    /// <summary>
    /// Gets sending domain collection resource for the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Sending domain collection resource for the account, represented by this resource instance.
    /// </returns>
    public ISendingDomainCollectionResource SendingDomains();

    /// <summary>
    /// Gets resource for specific sending domain, identified by <paramref name="domainId"/>.
    /// </summary>
    ///
    /// <param name="domainId">
    /// ID of sending domain to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the sending domain with specified ID.
    /// </returns>
    public ISendingDomainResource SendingDomain(long domainId);

    /// <summary>
    /// Gets project collection resource for the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Project collection resource for the account, represented by this resource instance.
    /// </returns>
    public IProjectCollectionResource Projects();

    /// <summary>
    /// Gets resource for specific project, identified by <paramref name="projectId"/>.
    /// </summary>
    ///
    /// <param name="projectId">
    /// ID of project to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the project with specified ID.
    /// </returns>
    public IProjectResource Project(long projectId);

    /// <summary>
    /// Gets inbox collection resource for the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Inbox collection resource for the account, represented by this resource instance.
    /// </returns>
    public IInboxCollectionResource Inboxes();

    /// <summary>
    /// Gets resource for specific inbox, identified by <paramref name="inboxId"/>.
    /// </summary>
    ///
    /// <param name="inboxId">
    /// ID of inbox to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the inbox with specified ID.
    /// </returns>
    public IInboxResource Inbox(long inboxId);


    /// <summary>
    /// Gets details of the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing details of the account, represented by this resource instance.
    /// </returns>
    public Task<Response<AccountDetails>> GetDetails(CancellationToken cancellationToken = default);
}
