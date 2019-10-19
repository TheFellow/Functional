using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Flatten<T, TResult>(this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
            sequence.Select(map)
                .OfType<Some<TResult>>()
                .Select(s => s.Content);
    }
}
