using Demo.Model;
using Functional.Option;

namespace Demo.OptionDemos
{
    public class FlattenDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "IEnumerable<T>.Flatten(Func<T, Option<T>)";

        protected override void DoDemo()
        {
            var cars = new Car[]
            {
                new Car("Bob's Car", Color.Blue),
                new Car("Charles' Car", Color.Red),
                new Car("Brad's Car", Color.Green)
            };

            static Option<Car> carsWithB(Car car) =>
                car.Name.Contains('B')
                    ? car
                    : (Option<Car>)None.Value;

            var BOwners = cars.Flatten(carsWithB);

            Write(string.Join<Car>(", ", cars));
            Write(string.Join(", ", BOwners));
        }
    }
}
