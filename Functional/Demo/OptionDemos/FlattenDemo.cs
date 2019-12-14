using Demo.Model;
using Functional;

namespace Demo.OptionDemos
{
    public class FlattenDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "IEnumerable<T>.FirstOrNone()";

        protected override void DoDemo()
        {
            Car[] cars = new Car[] { new Car("Bob's car", Color.Blue), new Car("Charles' Car", Color.Red) };

            var blueCar = cars.FirstOrNone(car => car.Color == Color.Blue);
            var greenCar = cars.FirstOrNone(car => car.Color == Color.Green);

            Write($"{blueCar}, {greenCar}");
        }
    }
}
