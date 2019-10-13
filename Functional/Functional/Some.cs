namespace Functional
{
    public sealed class Some<T> : Option<T>
    {
        public T Content { get; }
        public Some(T Content) => this.Content = Content;

        public static implicit operator T(Some<T> some) => some.Content;
        public static implicit operator Some<T>(T content) => new Some<T>(content);

        public override string ToString() => $"Some({Content})";
    }
}
