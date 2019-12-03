using System;

namespace Functional
{
    public static class OptionObjectExtensions
    {
        public static Option<T> NoneIfNull<T>(this T obj) =>
            obj.When(!(obj is null));

        public static Option<T> When<T>(this T obj, bool condition) =>
            condition ? (Option<T>)obj : None.Value;

        public static Option<T> When<T>(this T obj, Func<bool> predicate) =>
            predicate() ? (Option<T>)obj : None.Value;

        public static Option<T> When<T>(this T obj, Func<T, bool> predicate) =>
            predicate(obj) ? (Option<T>)obj : None.Value;
    }
}
