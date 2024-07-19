namespace DzCoffee.Drinks
{
    public class AbstractDrink
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public AbstractDrink(string name, double price)
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
