using Demo.Model;
using Functional.Either;

namespace Demo.EitherDemos
{
    public class EitherMapDemo : Demo
    {
        public override string Type => "Either";

        public override string Title => "Either.Map()";

        protected override void DoDemo()
        {
            Either<Car, Truck> car = new Car("Bob's Car", Color.Blue);
            Either<Car, Truck> truck = new Truck(3, Color.Red);

            static Truck doubleAxles(Truck t) => new Truck(t.Axles * 2, t.Color);

            var mappedCar = car.Map(doubleAxles);
            var mappedTruck = truck.Map(doubleAxles);

            Write($"{car}, {truck}");
            Write($"{mappedCar}, {mappedTruck}");
        }
    }
}
