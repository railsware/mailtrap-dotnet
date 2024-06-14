// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Text.Json;
global using System.Text.Json.Serialization;
global using Microsoft.Extensions.Options;
global using FluentValidation;

global using Mailtrap.Authentication;
global using Mailtrap.Constants;
global using Mailtrap.Extensions;
global using Mailtrap.Http;
global using Mailtrap.Http.Lifetime;
global using Mailtrap.Http.Request;
global using Mailtrap.Configuration;
global using Mailtrap.Configuration.Models;
global using Mailtrap.Core;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;
global using Mailtrap.Email.Validators;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
