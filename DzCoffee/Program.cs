using DzCoffee.DataManager;
using DzCoffee.Drinks;
using DzCoffee.Machines;

namespace DzCoffee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeReceipesDataManager hotManager = new CoffeeReceipesDataManager("Data/coffeeReceipes");

            hotManager.AddReceipe(hotManager.WriteReceipe());

            Dictionary<string, HotDrink> hotDrinks = hotManager.ReturnReceipesDict();

            CoffeeMachine CoffeeMachineFirst = new CoffeeMachine(100, 100, 100, 100, hotDrinks);


            ColdDrinksDataManager coldManager = new ColdDrinksDataManager("Data/coldDrinks");

            coldManager.AddDrink(coldManager.WriteParameters());

            Dictionary<string, ColdDrink> coldDrinks = coldManager.ReturnDrinksDict();

            ColdDrinksMachine ColdDrinksMachineFirst = new ColdDrinksMachine(coldDrinks);

            while (true)
            {
                try
                {
                    CoffeeMachineFirst.GetHotDrink();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Беда в кофейном автомате {e.Message}");
                }
                try
                {
                    ColdDrinksMachineFirst.GetColdDrink();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Беда в газировочном автомате {e.Message}");
                }
            }
        }
    }
}
