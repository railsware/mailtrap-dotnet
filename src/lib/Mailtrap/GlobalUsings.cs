// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Net.Http.Headers;
global using Microsoft.Extensions.Options;
global using FluentValidation;

global using Mailtrap.Constants;
global using Mailtrap.Extensions;
global using Mailtrap.Configuration;
global using Mailtrap.Configuration.Models;
global using Mailtrap.Core.Models;
global using Mailtrap.Core.Converters;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
