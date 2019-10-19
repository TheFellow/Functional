namespace Functional
{
    public sealed class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        public TRight Content { get; }
        public Right(TRight either) => Content = either;

        public static implicit operator TRight(Right<TLeft, TRight> either) => either.Content;
    }
}
