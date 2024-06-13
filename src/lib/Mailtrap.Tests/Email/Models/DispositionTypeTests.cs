// -----------------------------------------------------------------------
// <copyright file="DispositionTypeTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Models;


[TestFixture]
internal sealed class DispositionTypeTests
{
    [Test]
    public void PredefinedEnumValuesShouldBeCorrect()
    {
        DispositionType.Inline.ToString().Should().Be("inline");
        DispositionType.Attachment.ToString().Should().Be("attachment");
    }
}
