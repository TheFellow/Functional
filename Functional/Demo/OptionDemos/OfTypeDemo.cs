using Demo.Model;
using Functional.Option;
using System.Linq;

namespace Demo.OptionDemos
{
    public class OfTypeDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "Option<T>.OfType<T>()";

        protected override void DoDemo()
        {
            var vehicles = new Vehicle[]
            {
                new Car("Bob's Car", Color.Blue),
                new Car("Charles' Car", Color.Green),
                new Truck(3, Color.Red),
                new Truck(4, Color.Green),
                new Car("Frank's Car", Color.Red)
            };

            var trucks = vehicles.Select(v => v.When(t => t is Truck));

            Write(string.Join<Vehicle>(", ", vehicles));
            Write(string.Join(", ", trucks));
        }
    }
}
