namespace Demo.Model
{
    public class Car : Vehicle
    {
        public string Name => _name;
        private readonly string _name;

        public Car(string name, Color color) : base(color) => _name = name;

        public override string ToString() => $"{_name} {Color}";
    }
}
