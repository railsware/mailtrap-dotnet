// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilderTests.Header.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Header = System.Collections.Generic.KeyValuePair<string, string>;


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailRequestBuilder))]
internal sealed class SendEmailRequestBuilderTests_Header
{

    private string HeaderKey { get; } = "key";
    private string HeaderValue { get; } = "value";
    private Header _header1 { get; } = new("Key-1", "Value 1");
    private Header _header2 { get; } = new("Key-2", "Value 2");



    #region Header

    [Test]
    public void Header_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailRequestBuilder.Header(null!, _header1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Header_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Header_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void Header_ShouldAddHeadersToCollection()
    {
        Header_CreateAndValidate(_header1, _header2);
    }

    [Test]
    public void Header_ShouldAddHeadersToCollection_WhenCalledMultipleTimes()
    {
        var header3 = new Header("key-3", "Value 3");
        var header4 = new Header("key-4", "Value 4");

        var request = Header_CreateAndValidate(_header1, _header2);

        request.Header(header3, header4);

        request.Headers.Should()
            .HaveCount(4).And
            .ContainInOrder(_header1, _header2, header3, header4);
    }

    [Test]
    public void Header_ShouldShouldOverrideHeaders_WhenCalledMultipleTimesWithTheSameKeys()
    {
        var header3 = new Header("key-3", "Value 3");

        var request = Header_CreateAndValidate(_header1, _header2);

        request.Header(_header1, header3);

        request.Headers.Should()
            .HaveCount(3).And
            .ContainInOrder(_header1, _header2, header3);
    }

    [Test]
    public void Header_ShouldNotAddHeadersToCollection_WhenParamsIsEmpty()
    {
        var request = Header_CreateAndValidate(_header1, _header2);

        request.Header([]);

        request.Headers.Should()
            .HaveCount(2).And
            .ContainInOrder(_header1, _header2);
    }


    private static SendEmailRequest Header_CreateAndValidate(params Header[] headers)
    {
        var request = SendEmailRequest
            .Create()
            .Header(headers);

        request.Headers.Should()
            .HaveCount(2).And
            .ContainInOrder(headers);

        return request;
    }

    #endregion



    #region Header(key, value)

    [Test]
    public void Header_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(null!, HeaderKey, HeaderValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Header_ShouldThrowArgumentNullException_WhenHeaderKeyIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(request, null!, HeaderValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Header_ShouldThrowArgumentNullException_WhenHeaderKeyIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(request, string.Empty, HeaderValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Header_ShouldNotThrowException_WhenHeaderValueIsNull()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(request, HeaderKey, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void Header_ShouldNotThrowException_WhenHeaderValueIsEmpty()
    {
        var request = SendEmailRequest.Create();

        var act = () => SendEmailRequestBuilder.Header(request, HeaderKey, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Header_ShouldAddHeaderToCollection_2()
    {
        Header_CreateAndValidate(HeaderKey, HeaderValue);
    }

    [Test]
    public void Header_ShouldAddHeadersToCollection_WhenCalledMultipleTimes_2()
    {
        var key = "key-2";
        var value = "Value 2";

        var request = Header_CreateAndValidate(HeaderKey, HeaderValue);

        request.Header(key, value);

        request.Headers.Should().HaveCount(2);

        request.Headers.Should().ContainKeys(HeaderKey, key);

        request.Headers[HeaderKey].Should().Be(HeaderValue);

        request.Headers[key].Should().Be(value);
    }

    [Test]
    public void Header_ShouldOverrideHeader_WhenCalledMultipleTimesWithTheSameKey_2()
    {
        var otherValue = "Other Value";

        var request = Header_CreateAndValidate(HeaderKey, HeaderValue);

        request.Header(HeaderKey, otherValue);

        request.Headers.Should().ContainSingle();

        request.Headers.Should().ContainKey(HeaderKey);

        request.Headers[HeaderKey].Should().Be(otherValue);
    }


    private static SendEmailRequest Header_CreateAndValidate(string key, string value)
    {
        var request = SendEmailRequest
            .Create()
            .Header(key, value);

        request.Headers.Should().ContainSingle();

        request.Headers.Should().ContainKey(key);

        request.Headers[key].Should().Be(value);

        return request;
    }

    #endregion
}
