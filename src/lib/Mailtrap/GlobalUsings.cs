// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Net.Http.Headers;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using FluentValidation;

global using Mailtrap.Constants;
global using Mailtrap.Extensions;
global using Mailtrap.Extensions.DependencyInjection;
global using Mailtrap.Configuration;
global using Mailtrap.Configuration.Models;
global using Mailtrap.Configuration.Validators;
global using Mailtrap.Authentication;
global using Mailtrap.Http.Lifetime;
global using Mailtrap.Http.Request;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;
global using Mailtrap.Email.Validators;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
