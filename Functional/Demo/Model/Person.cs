using Functional.Optional;

namespace Demo.Model
{
    public class Person
    {
        public Person(string name, int age, Color favoriteColor)
        {
            Name = name;
            Age = age;
            FavoriteColor = favoriteColor;
        }

        public string Name { get; }
        public int Age { get; }
        public Color FavoriteColor { get; }

        public Option<Car> GetCar() =>
            Age >= 16
                ? (Option<Car>)new Car($"{Name}'s {FavoriteColor.ToString().ToLower()} car", FavoriteColor)
                : None.Value;
    }
}
