namespace Functional
{
    public sealed class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TLeft Content { get; }
        public Left(TLeft content) => Content = content;

        public static implicit operator TLeft(Left<TLeft, TRight> either) => either.Content;
    }
}
