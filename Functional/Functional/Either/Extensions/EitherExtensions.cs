﻿using System;

namespace Functional
{
    public static class EitherExtensions
    {
        public static TRight Reduce<TLeft, TRight>(this Either<TLeft, TRight> either, TRight whenLeft) =>
            either is Right<TLeft, TRight> right ? right.Content : whenLeft;

        public static TRight Reduce<TLeft, TRight>(this Either<TLeft, TRight> either, Func<TRight> whenLeft) =>
            either is Right<TLeft, TRight> right ? right.Content : whenLeft();

        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, TNewRight> map) =>
            either is Right<TLeft, TRight> right
                ? (Either<TLeft, TNewRight>)map(right.Content)
                : (TLeft)(Left<TLeft, TRight>)either;
    }
}
