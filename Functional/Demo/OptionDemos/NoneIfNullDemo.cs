using Demo.Model;
using Functional.Optional;

namespace Demo.OptionDemos
{
    public class NoneIfNullDemo : Demo
    {
        public override string Title => "Object.NoneIfNull()";

        public override string Type => "Option";

        protected override void DoDemo()
        {
            Color color = Color.Red;
            Option<Color> maybeColor1 = color.NoneIfNull();

            Write($"{color} => {maybeColor1}");

            color = null!;
            Option<Color> maybeColor2 = color.NoneIfNull();

            Write($"{color} => {maybeColor2}");
        }
    }
}
