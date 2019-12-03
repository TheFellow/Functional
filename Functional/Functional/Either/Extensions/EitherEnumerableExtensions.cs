using System;
using System.Collections.Generic;

namespace Functional
{
    public static class EitherEnumerableExtensions
    {
        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, TLeft whenEmpty) =>
            seq.FirstOrNone() is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty;

        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, Func<TRight, bool> predicate, TLeft whenEmpty) =>
            seq.FirstOrNone(predicate) is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty;

        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, Func<TLeft> whenEmpty) =>
            seq.FirstOrNone() is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty();

        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, Func<TRight, bool> predicate, Func<TLeft> whenEmpty) =>
            seq.FirstOrNone(predicate) is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty();
    }
}
