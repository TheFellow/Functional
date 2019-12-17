using Demo.Model;
using Functional;

namespace Demo.OptionDemos
{
    public class OptionImplicitCastDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "Implicit Cast";

        protected override void DoDemo()
        {
            Option<Car> option = new Car("Red Car", Color.Red);
            Some<Car> some = new Car("Blue Car", Color.Blue);
            Car car = some;

            Write(option);
            Write(car);
        }
    }
}
