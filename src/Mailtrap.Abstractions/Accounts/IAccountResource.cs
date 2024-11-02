// -----------------------------------------------------------------------
// <copyright file="IAccountResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Accounts;


/// <summary>
/// Represents account resource.
/// </summary>
public interface IAccountResource : IRestResource
{
    /// <summary>
    /// Gets account access collection resource for the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Account access collection resource for the account, represented by this resource instance.
    /// </returns>
    public IAccountAccessCollectionResource Accesses();

    /// <summary>
    /// Gets resource for specific account access, identified by <paramref name="accessId"/>.
    /// </summary>
    ///
    /// <param name="accessId">
    /// ID of account access to get resource for.
    /// </param>
    /// 
    /// <returns>
    /// Resource for the account access with specified ID.
    /// </returns>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="accessId"/> is less than or equal to zero.
    /// </exception>
    public IAccountAccessResource Access(long accessId);

    /// <summary>
    /// Gets permissions resource for the account, represented by this resource instance.
    /// </summary>
    /// 
    /// <returns>
    /// Permissions resource for the account, represented by this resource instance.
    /// </returns>
    public IPermissionsResource Permissions();

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
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="domainId"/> is less than or equal to zero.
    /// </exception>
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
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="projectId"/> is less than or equal to zero.
    /// </exception>
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
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="inboxId"/> is less than or equal to zero.
    /// </exception>
    public IInboxResource Inbox(long inboxId);
}
