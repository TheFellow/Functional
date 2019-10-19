namespace Functional
{
    public static class EitherExtensions
    {
        public static TRight Reduce<TLeft, TRight>(this Either<TLeft, TRight> either, TRight whenLeft) =>
            either is Right<TLeft, TRight> right ? right.Content : whenLeft;


    }
}
