// -----------------------------------------------------------------------
// <copyright file="GlobalUsings.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;
global using System.Net;
global using System.Net.Mime;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using Microsoft.Extensions.Options;

global using FluentValidation.Results;
global using FluentValidation.TestHelper;

global using NUnit.Framework;
global using FluentAssertions;
global using Moq;
global using RichardSzalay.MockHttp;

global using Mailtrap.Tests.TestExtensions;
global using Mailtrap.Core.Exceptions;
global using Mailtrap.Core.Responses;
global using Mailtrap.Constants;
global using Mailtrap.Extensions;
global using Mailtrap.Configuration;
global using Mailtrap.Http;
global using Mailtrap.Email;
global using Mailtrap.Email.Converters;
global using Mailtrap.Email.Models;
global using Mailtrap.Email.Requests;
global using Mailtrap.Email.Responses;
global using Mailtrap.Email.Validators;
