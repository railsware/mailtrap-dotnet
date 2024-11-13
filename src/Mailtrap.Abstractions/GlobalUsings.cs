// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Collections.Concurrent;
global using System.Diagnostics.CodeAnalysis;
global using System.Net;
global using System.Net.Mime;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using FluentValidation;
global using Mailtrap.AccountAccesses;
global using Mailtrap.AccountAccesses.Models;
global using Mailtrap.AccountAccesses.Requests;
global using Mailtrap.AccountAccesses.Responses;
global using Mailtrap.AccountAccesses.Validators;
global using Mailtrap.Accounts;
global using Mailtrap.Accounts.Models;
global using Mailtrap.Billing;
global using Mailtrap.Billing.Models;
global using Mailtrap.Email;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;
global using Mailtrap.Email.Validators;
global using Mailtrap.Exceptions;
global using Mailtrap.Extensions;
global using Mailtrap.Models;
global using Mailtrap.Permissions;
global using Mailtrap.Permissions.Models;
global using Mailtrap.Rest;
global using Mailtrap.Validation;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.UnitTests")]
[assembly: InternalsVisibleTo("Mailtrap.IntegrationTests")]
