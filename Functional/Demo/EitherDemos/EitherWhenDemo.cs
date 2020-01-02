using Demo.Model;
using Functional;
using Functional.Either;

namespace Demo.EitherDemos
{
    public class EitherWhenDemo : Demo
    {
        public class NotATruck : Vehicle
        {
            public NotATruck(Color color) : base(color)
            {
            }
            public override string ToString() => "Not a truck";
        }
        public override string Type => "Either";

        public override string Title => "Either.When()";

        protected override void DoDemo()
        {
            Vehicle truck = new Truck(3, Color.Red);
            Vehicle car = new Car("Bob's Car", Color.Blue);

            var bigTruck = truck.When(v => v is Truck t && t.Axles > 2, new NotATruck(truck.Color));
            var smallCar = car.When(v => v is Truck t && t.Axles > 2, new NotATruck(car.Color));

            Write($"{truck}, {car}");
            Write($"{bigTruck}, {smallCar}");
        }
    }
}
