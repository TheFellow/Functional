using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class OptionExtensions
    {
        public static Option<T> NoneIfNull<T>(this T obj) =>
            !(obj is null)
                ? (Option<T>)new Some<T>(obj)
                : new None<T>();

        #region Reduce

        public static T Reduce<T>(this Option<T> option, T whenNone) =>
            option is Some<T> some
                ? some.Content
                : whenNone;

        public static T Reduce<T>(this Option<T> option, Func<T> whenNone) =>
            option is Some<T> some
                ? some.Content
                : whenNone();

        #endregion

        #region Map

        public static Option<TNew> Map<T, TNew>(this Option<T> option, Func<T, TNew> map) =>
            option is Some<T> some
                ? (Option<TNew>)map(some.Content)
                : new None<TNew>();

        public static Option<TNew> Map<T, TNew>(this Option<T> option, Func<T, Option<TNew>> map) =>
            option is Some<T> some
                ? (Option<TNew>)map(some.Content)
                : new None<TNew>();

        #endregion

        #region When

        public static Option<T> When<T>(this T obj, bool condition) =>
            condition ? (Option<T>)obj : None.Value;

        public static Option<T> When<T>(this T obj, Func<bool> predicate) =>
            predicate() ? (Option<T>)obj : None.Value;

        public static Option<T> When<T>(this T obj, Func<T, bool> predicate) =>
            predicate(obj) ? (Option<T>)obj : None.Value;

        #endregion
    }
}
