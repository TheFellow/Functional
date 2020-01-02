using Demo.Model;
using Functional.Optional;

namespace Demo.OptionDemos
{
    public class MappingDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "Option<T>.Map()";

        protected override void DoDemo()
        {
            var child = new Person("Alice", 10, Color.Green);
            var adult = new Person("Bob", 34, Color.Blue);

            var none = child.GetCar();
            var some = adult.GetCar();

            Write($"{none}, {some}");

            Option<Person> nobody = None.Value;
            Option<Person> someChild = child;
            Option<Person> someAdult = adult;

            var noCar = nobody.Map(p => p.GetCar());
            var noChildCar = someChild.Map(p => p.GetCar());
            var someAdultCar = someAdult.Map(p => p.GetCar());

            Write($"{noCar}, {noChildCar}, {someAdultCar}");
        }
    }
}
