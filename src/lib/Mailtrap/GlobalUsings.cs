// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


// Namespaces
global using System.Globalization;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Net.Http.Headers;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using FluentValidation;

global using Mailtrap.Constants;
global using Mailtrap.Extensions;
global using Mailtrap.Configuration;
global using Mailtrap.Http;
global using Mailtrap.Core.Exceptions;
global using Mailtrap.Core.Models;
global using Mailtrap.Core.Converters;
global using Mailtrap.Email;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;


// Type aliases
global using RequestHeader = System.Collections.Generic.KeyValuePair<string, string>;
global using RequestVariable = System.Collections.Generic.KeyValuePair<string, string>;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
