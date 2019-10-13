namespace FunctionalTests
{
    public class MyType1
    {
        public int Value { get; set; }
        public override string ToString() => nameof(MyType1);
    }
    public class MySubtype1 : MyType1 { }

    public class MyType2
    {
        public int Value { get; set; }
    }
}
