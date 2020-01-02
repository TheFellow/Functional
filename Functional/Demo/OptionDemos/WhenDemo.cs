using Demo.Model;
using Functional.Optional;

namespace Demo.OptionDemos
{
    public class WhenDemo : Demo
    {
        public override string Type => "Option";

        public override string Title => "Object.When()";

        protected override void DoDemo()
        {
            var favorite = Color.Blue;
            var likeColor = Color.Blue.When(c => c == favorite);
            var dislikeColor = Color.Red.When(c => c == favorite);

            Write($"{favorite} => {likeColor}");
            Write($"{Color.Red} => {dislikeColor}");
        }
    }
}
