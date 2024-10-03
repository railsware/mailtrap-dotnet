// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


// Namespaces
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Net.Mime;

global using Mailtrap.Extensions;
global using Mailtrap.Core.Models;
global using Mailtrap.Core.Responses;
global using Mailtrap.Account;
global using Mailtrap.Account.Models;
global using Mailtrap.AccountAccess;
global using Mailtrap.AccountAccess.Models;
global using Mailtrap.AccountAccess.Requests;
global using Mailtrap.Permissions;
global using Mailtrap.Permissions.Models;
global using Mailtrap.Billing;
global using Mailtrap.Billing.Models;
global using Mailtrap.SendingDomain;
global using Mailtrap.SendingDomain.Models;
global using Mailtrap.SendingDomain.Requests;
global using Mailtrap.Project;
global using Mailtrap.Project.Models;
global using Mailtrap.Project.Requests;
global using Mailtrap.Inbox;
global using Mailtrap.Inbox.Models;
global using Mailtrap.Inbox.Requests;
global using Mailtrap.Message;
global using Mailtrap.Message.Models;
global using Mailtrap.Message.Requests;
global using Mailtrap.MessageAttachment;
global using Mailtrap.MessageAttachment.Models;
global using Mailtrap.Email;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Converters;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;


// Type aliases
global using RequestHeader = System.Collections.Generic.KeyValuePair<string, string>;
global using RequestVariable = System.Collections.Generic.KeyValuePair<string, string>;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Mailtrap.Tests")]
