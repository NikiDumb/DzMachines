namespace DzCoffee.Drinks
{
    public class HotDrink : Drink
    {
        public double WaterNeeded { get; set; }

        public double CoffeePowderNeeded { get; set; }

        public double MilkNeeded { get; set; }

        public int SugarNeeded { get; set; }


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
