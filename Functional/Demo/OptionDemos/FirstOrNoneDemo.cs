using Demo.Model;
using Functional.Option;

namespace Demo.OptionDemos
{
    public class FirstOrNoneDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "IEnumerable<T>.FirstOrNone()";

        protected override void DoDemo()
        {
            var cars = new Car[]
            {
                new Car("Bob's car", Color.Blue),
                new Car("Charles' Car", Color.Red)
            };

            var blueCar = cars.FirstOrNone(car => car.Color == Color.Blue);
            var greenCar = cars.FirstOrNone(car => car.Color == Color.Green);

            Write($"{blueCar}, {greenCar}");
        }
    }
}
