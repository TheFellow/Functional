using Demo.Model;
using Functional;

namespace Demo.EitherDemos
{
    public class EitherTeeDemo : Demo
    {
        public override string Type => "Either";

        public override string Title => "Either.Tee()";

        protected override void DoDemo()
        {
            var vehicles = new Either<Truck, Car>[]
            {
                new Car("Bob's Car", Color.Blue),
                new Truck(3, Color.Red),
                new Car("Evan's Car", Color.Red)
            };

            foreach (var v in vehicles)
                Write($"{v.Tee(c => Write("Found a car!"))}");
        }
    }
}
