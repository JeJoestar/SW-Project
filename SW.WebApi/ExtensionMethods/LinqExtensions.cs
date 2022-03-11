// <copyright file="LinqExtensions.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.WebAPI.ExtensionMethods
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> NotEachSecond<TSource>(this IEnumerable<TSource> entities, Func<TSource, bool> predicate)
        {
            int i = 0;
            foreach (var entity in entities)
            {
                i++;
                if (predicate(entity) || (i % 2 != 0))
                {
                    yield return entity;
                }
            }
        }
    }
}
