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
    }
}
