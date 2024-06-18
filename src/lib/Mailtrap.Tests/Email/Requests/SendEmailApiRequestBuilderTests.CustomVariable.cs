// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilderTests.Variable.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Variable = System.Collections.Generic.KeyValuePair<string, string>;


namespace Mailtrap.Tests.Email.Requests;


[TestFixture(TestOf = typeof(SendEmailApiRequestBuilder))]
internal sealed class SendEmailApiRequestBuilderTests_CustomVariable
{

    private string VariableKey { get; } = "key";
    private string VariableValue { get; } = "value";
    private Variable _variable1 { get; } = new("Key-1", "Value 1");
    private Variable _variable2 { get; } = new("Key-2", "Value 2");



    #region WithCustomVariables

    [Test]
    public void WithCustomVariables_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithCustomVariables<RegularSendEmailApiRequest>(null!, _variable1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCustomVariables_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariables(request, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithCustomVariables_ShouldNotThrowException_WhenParamsIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariables(request, []);

        act.Should().NotThrow();
    }

    [Test]
    public void WithCustomVariables_ShouldAddVariablesToCollection()
    {
        WithCustomVariables_CreateAndValidate(_variable1, _variable2);
    }

    [Test]
    public void WithCustomVariables_ShouldAddVariablesToCollection_WhenCalledMultipleTimes()
    {
        var variable3 = new Variable("key-3", "Value 3");
        var variable4 = new Variable("key-4", "Value 4");

        var request = WithCustomVariables_CreateAndValidate(_variable1, _variable2);

        request.WithCustomVariables(variable3, variable4);

        request.CustomVariables.Should()
            .HaveCount(4).And
            .ContainInOrder(_variable1, _variable2, variable3, variable4);
    }

    [Test]
    public void WithCustomVariables_ShouldShouldOverrideVariables_WhenCalledMultipleTimesWithTheSameKeys()
    {
        var variable3 = new Variable("key-3", "Value 3");

        var request = WithCustomVariables_CreateAndValidate(_variable1, _variable2);

        request.WithCustomVariables(_variable1, variable3);

        request.CustomVariables.Should()
            .HaveCount(3).And
            .ContainInOrder(_variable1, _variable2, variable3);
    }

    [Test]
    public void WithCustomVariables_ShouldNotAddVariablesToCollection_WhenParamsIsEmpty()
    {
        var request = WithCustomVariables_CreateAndValidate(_variable1, _variable2);

        request.WithCustomVariables([]);

        request.CustomVariables.Should()
            .HaveCount(2).And
            .ContainInOrder(_variable1, _variable2);
    }


    private static RegularSendEmailApiRequest WithCustomVariables_CreateAndValidate(params Variable[] headers)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCustomVariables(headers);

        request.CustomVariables.Should()
            .HaveCount(2).And
            .ContainInOrder(headers);

        return request;
    }

    #endregion



    #region WithVariable(header)

    [Test]
    public void WithVariable_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var act = () => SendEmailApiRequestBuilder.WithCustomVariable<RegularSendEmailApiRequest>(null!, _variable1);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithVariable_ShouldAddVariableToCollection()
    {
        WithVariable_CreateAndValidate(_variable1);
    }

    [Test]
    public void WithVariable_ShouldAddVariableToCollection_WhenCalledMultipleTimes()
    {
        var request = WithVariable_CreateAndValidate(_variable1);

        request.WithCustomVariable(_variable2);

        request.CustomVariables.Should()
            .HaveCount(2).And
            .ContainInOrder(_variable1, _variable2);
    }

    [Test]
    public void WithVariable_ShouldOverrideVariable_WhenCalledMultipleTimesWithTheSameKey()
    {
        var variable2 = new Variable(_variable1.Key, "Other Value");

        var request = WithVariable_CreateAndValidate(_variable1);

        request.WithCustomVariable(variable2);

        request.CustomVariables.Should()
            .ContainSingle().And
            .Contain(variable2);
    }


    private static RegularSendEmailApiRequest WithVariable_CreateAndValidate(Variable header)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCustomVariable(header);

        request.CustomVariables.Should()
            .ContainSingle().And
            .Contain(header);

        return request;
    }

    #endregion



    #region WithVariable(key, value)

    [Test]
    public void WithVariable_ShouldThrowArgumentNullException_WhenRequestIsNull_2()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariable<RegularSendEmailApiRequest>(null!, VariableKey, VariableValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithVariable_ShouldThrowArgumentNullException_WhenVariableKeyIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariable(request, null!, VariableValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithVariable_ShouldThrowArgumentNullException_WhenVariableKeyIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariable(request, string.Empty, VariableValue);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithVariable_ShouldNotThrowException_WhenVariableValueIsNull()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariable(request, VariableKey, null!);

        act.Should().NotThrow();
    }

    [Test]
    public void WithVariable_ShouldNotThrowException_WhenVariableValueIsEmpty()
    {
        var request = SendEmailApiRequestBuilder.Create<RegularSendEmailApiRequest>();

        var act = () => SendEmailApiRequestBuilder.WithCustomVariable(request, VariableKey, string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void WithVariable_ShouldAddVariableToCollection_2()
    {
        WithVariable_CreateAndValidate(VariableKey, VariableValue);
    }

    [Test]
    public void WithVariable_ShouldAddVariablesToCollection_WhenCalledMultipleTimes()
    {
        var key = "key-2";
        var value = "Value 2";

        var request = WithVariable_CreateAndValidate(VariableKey, VariableValue);

        request.WithCustomVariable(key, value);

        request.CustomVariables.Should().HaveCount(2);

        request.CustomVariables.Should().ContainKeys(VariableKey, key);

        request.CustomVariables[VariableKey].Should().Be(VariableValue);

        request.CustomVariables[key].Should().Be(value);
    }

    [Test]
    public void WithVariable_ShouldOverrideVariable_WhenCalledMultipleTimesWithTheSameKey_2()
    {
        var otherValue = "Other Value";

        var request = WithVariable_CreateAndValidate(VariableKey, VariableValue);

        request.WithCustomVariable(VariableKey, otherValue);

        request.CustomVariables.Should().ContainSingle();

        request.CustomVariables.Should().ContainKey(VariableKey);

        request.CustomVariables[VariableKey].Should().Be(otherValue);
    }


    private static RegularSendEmailApiRequest WithVariable_CreateAndValidate(string key, string value)
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithCustomVariable(key, value);

        request.CustomVariables.Should().ContainSingle();

        request.CustomVariables.Should().ContainKey(key);

        request.CustomVariables[key].Should().Be(value);

        return request;
    }

    #endregion
}
