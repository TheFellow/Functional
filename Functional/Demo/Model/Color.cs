namespace Demo.Model
{
    public class Color
    {
        private readonly string _name;

        private Color(string color) => _name = color;
        public override string ToString() => _name;

        public static Color Red = new Color("Red");
        public static Color Blue = new Color("Blue");
        public static Color Green = new Color("Green");
    }
}
