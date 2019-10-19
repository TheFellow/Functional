namespace Functional
{
    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T some) => new Some<T>(some);
        public static implicit operator Option<T>(None _) => new None<T>();

        public Option<TNew> OfType<TNew>() where TNew : class =>
            this is Some<T> some && (some.Content as TNew != null)
                ? (Option<TNew>)new Some<TNew>((some.Content as TNew)!)  
                : None.Value;
    }
}
