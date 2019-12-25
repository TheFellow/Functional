using Demo.Model;
using Functional;

namespace Demo.EitherDemos
{
    public class FirstOrOtherDemo : Demo
    {
        public override string Type => "Either";

        public override string Title => "IEnumerable<TRight>.FirstOrOther(whenLeft)";

        protected override void DoDemo()
        {
            var vehicles = new Vehicle[]
            {
                new Car("Bob's Car", Color.Blue),
                new Truck(3, Color.Red),
                new Car("Dan's Car", Color.Red)
            };

            var redVehicle = vehicles.FirstOrOther(v => v.Color == Color.Red, new Car("No car", Color.Red));
            var greenVehicle = vehicles.FirstOrOther(v => v.Color == Color.Green, new Car("No car", Color.Green));

            Write($"{redVehicle}, {greenVehicle}");
        }
    }
}
