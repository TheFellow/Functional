using Functional.Option;
using System.Collections.Generic;

namespace Demo.OptionDemos
{
    public class TryGetValueDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "IDictionary<TKey, TValue>.TryGetValue()";

        protected override void DoDemo()
        {
            var dict = new Dictionary<int, string>
            {
                [1] = "One",
                [2] = "Two",
                [3] = "Three"
            };

            Write(string.Join(", ", dict.Values));
            Write($"{dict.TryGetValue(1)}, {dict.TryGetValue(2)}, {dict.TryGetValue(4)}");
        }
    }
}
