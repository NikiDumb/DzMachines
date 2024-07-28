using System.Text.Json.Serialization;

namespace DzCoffee.Drinks
{
    [JsonDerivedType(typeof(HotDrink), "Hot")]
    [JsonDerivedType(typeof(ColdDrink), "Cold")]
    public class AbstractDrink
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public AbstractDrink(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} за {Price}";
        }

        public override bool Equals(object? obj)
        {
            return obj is AbstractDrink drink &&
                   Name == drink.Name;
        }
    }
}
