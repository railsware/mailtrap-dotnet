// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


// Namespaces
global using System.Globalization;
global using System.Net;
global using System.Net.Http.Headers;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using FluentValidation;
global using Mailtrap.Accounts;
global using Mailtrap.Accounts.Models;
global using Mailtrap.Billing;
global using Mailtrap.Billing.Models;
global using Mailtrap.Configuration;
global using Mailtrap.Constants;
global using Mailtrap.Converters;
global using Mailtrap.Email;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;
global using Mailtrap.Exceptions;
global using Mailtrap.Extensions;
global using Mailtrap.Http;
global using Mailtrap.Http.ResponseHandlers;
global using Mailtrap.Models;
global using Mailtrap.Rest;
global using Mailtrap.Rest.Commands;
global using Mailtrap.Validation;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Options;


// Type aliases
global using RequestHeader = System.Collections.Generic.KeyValuePair<string, string>;
global using RequestVariable = System.Collections.Generic.KeyValuePair<string, string>;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.UnitTests")]
[assembly: InternalsVisibleTo("Mailtrap.IntegrationTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
