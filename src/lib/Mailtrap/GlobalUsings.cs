// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Text.Json;
global using Microsoft.Extensions.Options;

global using Mailtrap.Authentication;
global using Mailtrap.Constants;
global using Mailtrap.Extensions;
global using Mailtrap.Helpers;
global using Mailtrap.Http;
global using Mailtrap.Http.Lifetime;
global using Mailtrap.Http.Request;
global using Mailtrap.Models;
global using Mailtrap.Configuration;
global using Mailtrap.Configuration.Models;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mailtrap.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
