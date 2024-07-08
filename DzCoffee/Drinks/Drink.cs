namespace DzCoffee.Drinks
{
    public class Drink
    {
        public string Name { get; private set; }

        public double Price { get; private set; }

        public Drink(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void PrintDrink()
        {
            Console.WriteLine($"Напиток {Name}");
            Console.WriteLine($"Стоимость {Price}руб");
            Console.WriteLine();
        }
    }
}
