// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


// Namespaces
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Net.Mime;

global using Mailtrap.Extensions;
global using Mailtrap.Core.Responses;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Converters;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;


// Type aliases
global using RequestHeader = System.Collections.Generic.KeyValuePair<string, string>;
global using RequestVariable = System.Collections.Generic.KeyValuePair<string, string>;


// Allowing test assembly to access internals for unit tests
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Mailtrap.Tests")]
