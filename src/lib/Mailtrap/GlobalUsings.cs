// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Text.Json;
global using System.Text.Json.Serialization;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.DependencyInjection;
global using FluentValidation;

global using Mailtrap.Constants;
global using Mailtrap.Core;
global using Mailtrap.Extensions;
global using Mailtrap.Configuration.Models;
global using Mailtrap.Configuration.Validators;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
