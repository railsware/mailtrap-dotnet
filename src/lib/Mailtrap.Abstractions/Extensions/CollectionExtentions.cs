// -----------------------------------------------------------------------
// <copyright file="CollectionExtentions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


internal static class CollectionExtentions
{
    internal static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        ExceptionHelpers.ThrowIfNull(collection, nameof(collection));

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
