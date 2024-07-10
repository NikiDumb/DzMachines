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

            Dictionary<string, HotDrink> hotDrinks = HotDataManager.ReturnReceipesDict();

            //HotDataManager.AddReceipe(HotDataManager.WriteReceipe());

            DrinksMachinesManager HotManager = new DrinksMachinesManager()
            {
                Machines = new List<Machine> 
                {
                    new CoffeeMachine
                    (
                        "Максем",
                        "Пионерская",
                        100,
                        100,
                        100,
                        100,
                        hotDrinks
                    ),

                    new CoffeeMachine
                    (
                        "Боба",
                        "Автово",
                        10,
                        10,
                        1,
                        1,
                        hotDrinks
                    ),
                },

                ErrorsWriter = new ErrorsDataManager("Data/hotErrors")
            };


            ColdDrinksDataManager ColdDataManager = new ColdDrinksDataManager("Data/coldDrinks");

            //ColdDataManager.AddDrink(ColdDataManager.WriteParameters());

            Dictionary<string, ColdDrink> coldDrinks = ColdDataManager.ReturnDrinksDict();

            DrinksMachinesManager ColdManager = new DrinksMachinesManager()
            {
                Machines = new List<Machine>()
                {
                    new ColdDrinksMachine
                    (
                        "Артурка",
                        "Дыбенко",
                        coldDrinks
                        ),
                    new ColdDrinksMachine
                    (
                        "Лупа",
                        "бенко",
                        coldDrinks
                        )
                },

                ErrorsWriter = new ErrorsDataManager("Data/coldErrors")
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
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine();
                //HotManager.PrintInfo();
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine();
                //HotManager.RunMachines();
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine();
                //HotManager.PrintInfo();
            }
        }
    }
}
