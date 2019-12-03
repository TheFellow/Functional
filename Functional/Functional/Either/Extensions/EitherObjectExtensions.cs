using System;

namespace Functional
{
    public static class EitherObjectExtensions
    {
        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, bool predicate, TLeft whenFalse) =>
            predicate
                ? (Either<TLeft, TRight>)obj
                : whenFalse;

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, bool predicate, Func<TLeft> whenFalse) =>
            predicate
                ? (Either<TLeft, TRight>)obj
                : whenFalse();

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, bool predicate, Func<TRight, TLeft> whenFalse) =>
            predicate
                ? (Either<TLeft, TRight>)obj
                : whenFalse(obj);

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, Func<bool> predicate, TLeft whenFalse) =>
            predicate()
                ? (Either<TLeft, TRight>)obj
                : whenFalse;

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, Func<bool> predicate, Func<TLeft> whenFalse) =>
            predicate()
                ? (Either<TLeft, TRight>)obj
                : whenFalse();

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, Func<bool> predicate, Func<TRight, TLeft> whenFalse) =>
            predicate()
                ? (Either<TLeft, TRight>)obj
                : whenFalse(obj);

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, Func<TRight, bool> predicate, TLeft whenFalse) =>
            predicate(obj)
                ? (Either<TLeft, TRight>)obj
                : whenFalse;

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, Func<TRight, bool> predicate, Func<TLeft> whenFalse) =>
            predicate(obj)
                ? (Either<TLeft, TRight>)obj
                : whenFalse();

        public static Either<TLeft, TRight> When<TLeft, TRight>(this TRight obj, Func<TRight, bool> predicate, Func<TRight, TLeft> whenFalse) =>
            predicate(obj)
                ? (Either<TLeft, TRight>)obj
                : whenFalse(obj);
    }
}
