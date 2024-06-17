// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class SendEmailApiRequestTests
{
    private EmailParty _sender { get; } = new("sender@domain.com", "Sender");
    private EmailParty _recipient1 { get; } = new("recipient1@domain.com", "Recipient 1");
    private string _subject { get; } = "Email Subject";



    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenSenderIsNull()
    {
        var act = () => new RegularSendEmailApiRequest(null!, _recipient1, _subject);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRecipientIsNull()
    {
        var act = () => new RegularSendEmailApiRequest(_sender, null!, _subject);

        act.Should().Throw<ArgumentNullException>();
    }
}
