// -----------------------------------------------------------------------
// <copyright file="ISendClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


internal interface ISendClientFactory
{
    ISendClient CreateTransactionalClient();
    ISendClient CreateBulkClient();
    ISendClient CreateTestClient(long inboxId);
}
