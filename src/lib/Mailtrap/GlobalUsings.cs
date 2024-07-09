// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Text.Json;
global using System.Text.Json.Serialization;
global using FluentValidation;

global using Mailtrap.Core;
global using Mailtrap.Configuration;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
