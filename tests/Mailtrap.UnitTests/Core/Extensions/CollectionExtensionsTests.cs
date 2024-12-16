// -----------------------------------------------------------------------
// <copyright file="CollectionExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using CollectionExtensions = Mailtrap.Core.Extensions.CollectionExtensions;


namespace Mailtrap.UnitTests.Core.Extensions;


[TestFixture]
internal sealed class CollectionExtensionsTests
{
    [Test]
    public void AddRange_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        var itemsToAdd = new List<int> { 4, 5, 6 };

        var act = () => CollectionExtensions.AddRange(null!, itemsToAdd);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddRange_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        var collection = new List<int> { 1, 2, 3 };

        var act = () => CollectionExtensions.AddRange(collection, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddRange_ShouldAddItemsToCollection_WhenTargetIsList()
    {
        var collection = new List<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        CollectionExtensions.AddRange(collection, itemsToAdd);

        collection.Should().ContainInOrder(1, 2, 3, 4, 5, 6);
    }

    [Test]
    public void AddRange_ShouldAddItemsToCollection_WhenTargetIsNotList()
    {
        var collection = new HashSet<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        collection.AddRange(itemsToAdd);

        collection.Should().ContainInOrder(1, 2, 3, 4, 5, 6);
    }
}
