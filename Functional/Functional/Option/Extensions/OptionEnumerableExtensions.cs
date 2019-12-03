using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional
{
    public static class OptionEnumerableExtensions
    {
        public static IEnumerable<TResult> Flatten<T, TResult>(this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
            sequence.Select(map)
                .OfType<Some<TResult>>()
                .Select(s => s.Content);

        public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
            sequence
                .Select(o => (Option<T>)new Some<T>(o))
                .DefaultIfEmpty(None.Value)
                .First();

        public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence, Func<T, bool> predicate) =>
            sequence
                .Where(predicate)
                .FirstOrNone();
    }
}
