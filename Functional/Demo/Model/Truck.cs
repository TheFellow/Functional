namespace Demo.Model
{
    public class Truck : Vehicle
    {
        public int Axles { get; }
        public Truck(int axles, Color color) : base(color) => Axles = axles;

        public override string ToString() => $"{Color} truck with {Axles} axles";

    }
}
