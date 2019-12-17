using Demo.EitherDemos;
using Demo.OptionDemos;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("== Functional Demo ==" + Environment.NewLine);
            Console.WriteLine("Select a demo or press enter to quit." + Environment.NewLine);

            DemoHost demos = SetupDemos();

            while (demos.ShowMenu()) ;
        }

        private static DemoHost SetupDemos() => new DemoHost()
            .AddDemo(new OptionImplicitCastDemo())
            .AddDemo(new OfTypeDemo())
            .AddDemo(new WhenDemo())
            .AddDemo(new NoneIfNullDemo())
            .AddDemo(new MappingDemo())
            .AddDemo(new ReduceDemo())
            .AddDemo(new TeeDemo())
            .AddDemo(new FirstOrNoneDemo())
            .AddDemo(new FlattenDemo())
            .AddDemo(new TryGetValueDemo())
            .AddDemo(new EitherImplicitCastDemo())
            .AddDemo(new EitherWhenDemo())
            .AddDemo(new EitherReduceDemo())
            .AddDemo(new EitherMapDemo())
            .AddDemo(new EitherTeeDemo())
            .AddDemo(new FirstOrDefaultDemo())
            ;
    }
}
