namespace DzCoffee.Drinks
{
    public class HotDrink : Drink
    {
        public double WaterNeeded { get; private set; }

        public double CoffeePowderNeeded { get; private set; }

        public double MilkNeeded { get; private set; }

        public int SugarNeeded { get; private set; }


        public HotDrink(string name, double waterNeeded, double coffeePowderNeeded, double milkNeeded, int sugarNeeded, double price)
            : base(name, price)
        {
            WaterNeeded = waterNeeded;
            CoffeePowderNeeded = coffeePowderNeeded;
            MilkNeeded = milkNeeded;
            SugarNeeded = sugarNeeded;
        }


    }
}
