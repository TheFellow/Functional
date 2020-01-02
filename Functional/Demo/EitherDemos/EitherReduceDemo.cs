using Demo.Model;
using Functional;
using Functional.Either;

namespace Demo.EitherDemos
{
    public class EitherReduceDemo : Demo
    {
        public override string Type => "Either";

        public override string Title => "Either.Reduce()";

        protected override void DoDemo()
        {
            Either<Car, Truck> car = new Car("Bob's Car", Color.Blue);
            Either<Car, Truck> truck = new Truck(3, Color.Red);

            var notATruck = car.Reduce(new Truck(2, Color.Blue));
            var isATruck = truck.Reduce(new Truck(2, Color.Blue));

            Write($"{car}, {truck}");
            Write($"{notATruck}, {isATruck}");
        }
    }
}
