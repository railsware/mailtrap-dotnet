// -----------------------------------------------------------------------
// <copyright file="CreateSendingDomainRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.SendingDomains.Requests;


[TestFixture]
internal sealed class CreateSendingDomainRequestTests
{
    private const string DomainName = "goo.gl";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new CreateSendingDomainRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new CreateSendingDomainRequest(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var request = new CreateSendingDomainRequest(DomainName);

        request.DomainName.Should().Be(DomainName);
    }
}
