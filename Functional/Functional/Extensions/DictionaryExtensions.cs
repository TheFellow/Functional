using System.Collections.Generic;

namespace Functional
{
    public static class DictionaryExtensions
    {
        public static Option<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) =>
            dict.TryGetValue(key, out TValue value)
                ? (Option<TValue>)new Some<TValue>(value)
                : None.Value;
    }
}
