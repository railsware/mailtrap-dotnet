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
        // Arrange
        var collection = new List<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        // Act
        Mailtrap.Core.CollectionExtensions.AddRange(collection, itemsToAdd);

        // Assert
        collection.Should().ContainInOrder(1, 2, 3, 4, 5, 6);
    }

    [Test]
    public void AddRange_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        // Arrange
        var itemsToAdd = new List<int> { 4, 5, 6 };
        var act = () => Mailtrap.Core.CollectionExtensions.AddRange(null!, itemsToAdd);

        // Act & Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddRange_ShouldThrowArgumentNullException_WhenParamsIsNull()
    {
        // Arrange
        var collection = new List<int> { 1, 2, 3 };
        var act = () => Mailtrap.Core.CollectionExtensions.AddRange(collection, null!);

        // Act & Assert
        act.Should().Throw<ArgumentNullException>();
    }
}
