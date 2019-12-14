using System;
using System.Collections.Generic;

namespace Functional
{
    public static class EitherEnumerableExtensions
    {
        /// <summary>
        /// Returns the first element of a sequence of <typeparamref name="TRight"/> else the substitute <typeparamref name="TLeft"/> <paramref name="whenEmpty"/>
        /// </summary>
        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, TLeft whenEmpty) =>
            seq.FirstOrNone() is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty;

        /// <summary>
        /// Returns the first element of a sequence of <typeparamref name="TRight"/> else the substitute <typeparamref name="TLeft"/> <paramref name="whenEmpty"/>
        /// </summary>
        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, Func<TRight, bool> predicate, TLeft whenEmpty) =>
            seq.FirstOrNone(predicate) is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty;

        /// <summary>
        /// Returns the first element of a sequence of <typeparamref name="TRight"/> else the substitute <typeparamref name="TLeft"/> <paramref name="whenEmpty"/>
        /// </summary>
        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, Func<TLeft> whenEmpty) =>
            seq.FirstOrNone() is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty();

        /// <summary>
        /// Returns the first element of a sequence of <typeparamref name="TRight"/> else the substitute <typeparamref name="TLeft"/> <paramref name="whenEmpty"/>
        /// </summary>
        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, Func<TRight, bool> predicate, Func<TLeft> whenEmpty) =>
            seq.FirstOrNone(predicate) is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty();
    }
}
