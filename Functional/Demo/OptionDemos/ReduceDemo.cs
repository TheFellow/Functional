using Demo.Model;
using Functional;

namespace Demo.OptionDemos
{
    public class ReduceDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "Option<T>.Reduce(whenNone)";

        protected override void DoDemo()
        {
            var child = new Person("Alice", 10, Color.Green);
            var adult = new Person("Bob", 34, Color.Blue);

            Option<Car> alicesCar = child.GetCar().Reduce(new Car($"{child.Name} *would* get this car in", child.FavoriteColor));
            Option<Car> bobsCar = adult.GetCar();

            Write($"{alicesCar}, {bobsCar}");
        }
    }
}
