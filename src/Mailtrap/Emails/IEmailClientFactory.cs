// -----------------------------------------------------------------------
// <copyright file="IEmailClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails;


/// <summary>
/// Factory to spawn instances of <see cref="IEmailClient"/>.
/// </summary>
internal interface IEmailClientFactory
{
    public IEmailClient Create(bool isBulk = false, long? inboxId = default);
    public IEmailClient CreateDefault();
    public IEmailClient CreateTransactional();
    public IEmailClient CreateBulk();
    public IEmailClient CreateTest(long inboxId);
}
