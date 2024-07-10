using DzCoffee.DataManager;
using DzCoffee.Drinks;
using DzCoffee.MachineManager;
using DzCoffee.Machines;

namespace DzCoffee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeReceipesDataManager HotDataManager = new CoffeeReceipesDataManager("Data/coffeeReceipes");

            //HotDataManager.AddReceipe(HotDataManager.WriteReceipe());

            Dictionary<string, HotDrink> hotDrinks = HotDataManager.ReturnReceipesDict();

            CoffeeMachine CoffeeMachineFirst = new CoffeeMachine("Максемка", "Пионерская", 100, 100, 100, 100, hotDrinks);


            ColdDrinksDataManager ColdDataManager = new ColdDrinksDataManager("Data/coldDrinks");

            //ColdDataManager.AddDrink(ColdDataManager.WriteParameters());

            Dictionary<string, ColdDrink> coldDrinks = ColdDataManager.ReturnDrinksDict();

            ColdDrinksMachine ColdDrinksMachineFirst = new ColdDrinksMachine("Артурка", "Дыбенко", coldDrinks);
            ColdDrinksMachine ColdDrinksMachineSecond = new ColdDrinksMachine("Боба", "бенко", coldDrinks);

            ErrorsDataManager ColdErrorsManager = new ErrorsDataManager("Data/coldErrors");

            ColdDrinksMachinesManager ColdManager = new ColdDrinksMachinesManager()
            {
                Machines = new List<ColdDrinksMachine>()
                {
                    ColdDrinksMachineFirst,
                    ColdDrinksMachineSecond
                },
                ErrorsWriter = ColdErrorsManager
            };
            
            while (true)
            {
                ColdManager.PrintInfo();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                ColdManager.RunMachines();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                ColdManager.PrintInfo();
            }

            //while (true)
            //{
            //    try
            //    {
            //        CoffeeMachineFirst.GetHotDrink();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine($"Беда в кофейном автомате {e.Message}");
            //    }
            //    try
            //    {
            //        ColdDrinksMachineFirst.GetColdDrink();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine($"Беда в газировочном автомате {e.Message}");
            //    }
            //}
        }
    }
}
