// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Text.Json;
global using FluentValidation;

global using Mailtrap.Constants;
global using Mailtrap.Models;
global using Mailtrap.Contracts;
global using Mailtrap.Extensions;
global using Mailtrap.Helpers;
global using Mailtrap.Behaviors;
global using Mailtrap.Options.Models;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
