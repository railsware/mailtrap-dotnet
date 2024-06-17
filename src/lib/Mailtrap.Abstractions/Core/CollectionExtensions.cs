// -----------------------------------------------------------------------
// <copyright file="CollectionExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core;


/// <summary>
/// A set of helpers for managing collections.
/// </summary>
internal static class CollectionExtensions
{
    internal static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        Ensure.NotNull(collection, nameof(collection));
        Ensure.NotNull(items, nameof(items));

        if (collection is List<T> list)
        {
            list.AddRange(items);
        }
        else
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
