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
}
