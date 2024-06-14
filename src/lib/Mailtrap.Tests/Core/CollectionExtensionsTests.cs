// -----------------------------------------------------------------------
// <copyright file="CollectionExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Core;



[TestFixture]
internal sealed class CollectionExtensionsTests
{
    [Test]
    public void AddRange_ShouldAddItemsToCollection()
    {
        var collection = new List<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        Mailtrap.Core.CollectionExtensions.AddRange(collection, itemsToAdd);

        collection.Should().ContainInOrder(1, 2, 3, 4, 5, 6);
    }

    [Test]
    public void AddRange_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        var itemsToAdd = new List<int> { 4, 5, 6 };

        var act = () => Mailtrap.Core.CollectionExtensions.AddRange(null!, itemsToAdd);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddRange_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var collection = new List<int> { 1, 2, 3 };

        var act = () => Mailtrap.Core.CollectionExtensions.AddRange(collection, null!);

        act.Should().Throw<ArgumentNullException>();
    }
}
