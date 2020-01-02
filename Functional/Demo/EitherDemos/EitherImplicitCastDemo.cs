using Functional.Either;

namespace Demo.EitherDemos
{
    public class EitherImplicitCastDemo : Demo
    {
        public override string Type => "Either";

        public override string Title => "Either Implicit Cast";

        protected override void DoDemo()
        {
            Either<int, string> intEither = 4;
            Either<int, string> stringEither = "Four";
            int @int = (Left<int, string>)intEither;
            string @string = (Right<int, string>)stringEither;

            Write($"{intEither}, {stringEither}");
            Write($"{@int}, {@string}");
        }
    }
}
