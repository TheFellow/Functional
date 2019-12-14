namespace Demo.Model
{
    public abstract class Vehicle
    {
        public Color Color { get; set; }

        public Vehicle(Color color)
        {
            Color = color;
        }
    }
}
