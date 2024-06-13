// -----------------------------------------------------------------------
// <copyright file="CollectionExtentions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core;


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
