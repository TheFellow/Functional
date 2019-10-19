using System;

namespace Functional
{
    public static class OptionExtensions
    {
        public static T Reduce<T>(this Option<T> option, T whenNone) =>
            option is Some<T> some
                ? some.Content
                : whenNone;

        public static T Reduce<T>(this Option<T> option, Func<T> whenNone) =>
            option is Some<T> some
                ? some.Content
                : whenNone();

        public static Option<TNew> Map<T, TNew>(this Option<T> option, Func<T, TNew> map) =>
            option is Some<T> some
                ? (Option<TNew>)map(some.Content)
                : new None<TNew>();

        public static Option<TNew> Map<T, TNew>(this Option<T> option, Func<T, Option<TNew>> map) =>
            option is Some<T> some
                ? map(some.Content)
                : new None<TNew>();
    }
}
