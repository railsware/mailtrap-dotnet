// -----------------------------------------------------------------------
// <copyright file="IEmailClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


internal interface IEmailClientFactory
{
    public IEmailClient Create(bool isBulk = false, long? inboxId = null);
    public IEmailClient CreateBulk();
    public IEmailClient CreateDefault();
    public IEmailClient CreateTest(long inboxId);
    public IEmailClient CreateTransactional();
}
