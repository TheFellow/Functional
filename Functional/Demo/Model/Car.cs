namespace Demo.Model
{
    public class Car : Vehicle
    {
        public string Name { get; }

        public Car(string name, Color color) : base(color) => Name = name;

        public override string ToString() => $"{Name} {Color}";
    }
}
