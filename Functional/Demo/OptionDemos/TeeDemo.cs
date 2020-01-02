using Demo.Model;
using Functional.Option;

namespace Demo.OptionDemos
{
    public class TeeDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "Option<T>.Tee()";

        protected override void DoDemo()
        {
            var alice = new Person("Alice", 10, Color.Green);
            var bob = new Person("Bob", 34, Color.Red);

            void LogCars(Person p) => p
                .GetCar()
                .Tee(c => Write($"Got {c}"));

            LogCars(alice);
            LogCars(bob);
        }
    }
}
