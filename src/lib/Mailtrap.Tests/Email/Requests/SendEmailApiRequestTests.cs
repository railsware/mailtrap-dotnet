// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class SendEmailApiRequestTests
{
    private readonly EmailParty _sender = new("sender@domain.com", "Sender");
    private readonly EmailParty _recipient = new("recipient@domain.com", "Recipient");
    private readonly string _subject = "Email Subject";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenSenderIsNull()
    {
        var act = () => new RegularSendEmailApiRequest(null!, _recipient, _subject);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRecipientIsNull()
    {
        var act = () => new RegularSendEmailApiRequest(_sender, null!, _subject);

        act.Should().Throw<ArgumentNullException>();
    }
}
