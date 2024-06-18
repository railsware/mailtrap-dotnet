// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Header.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Header = System.Collections.Generic.KeyValuePair<string, string>;


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_Headers
{

    private string HeaderKey { get; } = "key";
    private string HeaderValue { get; } = "value";
    private Header _header1 { get; } = new("Key-1", "Value 1");
    private Header _header2 { get; } = new("Key-2", "Value 2");



    #region WithHeaders

    [Test]
    public void WithHeaders_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithHeaders<RegularSendEmailApiRequest>(null!, _header1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHeaders_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeaders(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHeaders_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeaders(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHeaders_ShouldAddHeadersToCollection()
    {
        WithHeaders_CreateAndValidate(_header1, _header2);
    }

    [Test]
    public void WithHeaders_ShouldAddHeadersToCollection_WhenCalledMultipleTimes()
    {
        var header3 = new Header("key-3", "Value 3");
        var header4 = new Header("key-4", "Value 4");

        var request = WithHeaders_CreateAndValidate(_header1, _header2);

        request.WithHeaders(header3, header4);

        request.Headers.Should()
            .HaveCount(4).And
            .ContainInOrder(_header1, _header2, header3, header4);
    }

    [Test]
    public void WithHeaders_ShouldShouldOverrideHeaders_WhenCalledMultipleTimesWithTheSameKeys()
    {
        var header3 = new Header("key-3", "Value 3");

        var request = WithHeaders_CreateAndValidate(_header1, _header2);

        request.WithHeaders(_header1, header3);

        request.Headers.Should()
            .HaveCount(3).And
            .ContainInOrder(_header1, _header2, header3);
    }

    [Test]
    public void WithHeaders_ShouldNotAddHeadersToCollection_WhenParamsIsEmpty()
    {
        var request = WithHeaders_CreateAndValidate(_header1, _header2);

        request.WithHeaders([]);

        request.Headers.Should()
            .HaveCount(2).And
            .ContainInOrder(_header1, _header2);
    }


    private static RegularSendEmailApiRequest WithHeaders_CreateAndValidate(params Header[] headers)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHeaders(headers);

        request.Headers.Should()
            .HaveCount(2).And
            .ContainInOrder(headers);

        return request;
    }

    #endregion



    #region WithHeader(header)

    [Test]
    public void WithHeader_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithHeader<RegularSendEmailApiRequest>(null!, _header1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHeader_ShouldAddHeaderToCollection()
    {
        WithHeader_CreateAndValidate(_header1);
    }

    [Test]
    public void WithHeader_ShouldAddHeaderToCollection_WhenCalledMultipleTimes()
    {
        var request = WithHeader_CreateAndValidate(_header1);

        request.WithHeader(_header2);

        request.Headers.Should()
            .HaveCount(2).And
            .ContainInOrder(_header1, _header2);
    }

    [Test]
    public void WithHeader_ShouldOverrideHeader_WhenCalledMultipleTimesWithTheSameKey()
    {
        var header2 = new Header(_header1.Key, "Other Value");

        var request = WithHeader_CreateAndValidate(_header1);

        request.WithHeader(header2);

        request.Headers.Should()
            .ContainSingle().And
            .Contain(header2);
    }


    private static RegularSendEmailApiRequest WithHeader_CreateAndValidate(Header header)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHeader(header);

        request.Headers.Should()
            .ContainSingle().And
            .Contain(header);

        return request;
    }

    #endregion



    #region WithHeader(key, value)

    [Test]
    public void WithHeader_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeader<RegularSendEmailApiRequest>(null!, HeaderKey, HeaderValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHeader_ShouldThrowArgumentNullException_WhenHeaderKeyIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeader(request, null!, HeaderValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHeader_ShouldThrowArgumentNullException_WhenHeaderKeyIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeader(request, string.Empty, HeaderValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithHeader_ShouldNotThrowException_WhenHeaderValueIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeader(request, HeaderKey, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHeader_ShouldNotThrowException_WhenHeaderValueIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithHeader(request, HeaderKey, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithHeader_ShouldAddHeaderToCollection_2()
    {
        WithHeader_CreateAndValidate(HeaderKey, HeaderValue);
    }

    [Test]
    public void WithHeader_ShouldAddHeadersToCollection_WhenCalledMultipleTimes()
    {
        var key = "key-2";
        var value = "Value 2";

        var request = WithHeader_CreateAndValidate(HeaderKey, HeaderValue);

        request.WithHeader(key, value);

        request.Headers.Should().HaveCount(2);

        request.Headers.Should().ContainKeys(HeaderKey, key);

        request.Headers[HeaderKey].Should().Be(HeaderValue);

        request.Headers[key].Should().Be(value);
    }

    [Test]
    public void WithHeader_ShouldOverrideHeader_WhenCalledMultipleTimesWithTheSameKey_2()
    {
        var otherValue = "Other Value";

        var request = WithHeader_CreateAndValidate(HeaderKey, HeaderValue);

        request.WithHeader(HeaderKey, otherValue);

        request.Headers.Should().ContainSingle();

        request.Headers.Should().ContainKey(HeaderKey);

        request.Headers[HeaderKey].Should().Be(otherValue);
    }


    private static RegularSendEmailApiRequest WithHeader_CreateAndValidate(string key, string value)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithHeader(key, value);

        request.Headers.Should().ContainSingle();

        request.Headers.Should().ContainKey(key);

        request.Headers[key].Should().Be(value);

        return request;
    }

    #endregion
}
