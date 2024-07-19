namespace DzCoffee.Drinks
{
    public class ColdDrink : AbstractDrink
    {
        public int Count { get; set; }

        public ColdDrink(string name, double price, int count)
            : base(name, price)
        {
            Count = count;
        }
    }
}
