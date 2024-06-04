// -----------------------------------------------------------------------
// <copyright file="IMailtrapApiClientOptionsProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Options;


internal interface IMailtrapApiClientOptionsProvider
{
    MailtrapApiClientOptions Options { get; }
}
