using DzCoffee.DataManager;
using DzCoffee.Drinks;
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

            ColdDrinksDataManager ColdDataManager = new ColdDrinksDataManager("Data/coldDrinks");

            //ColdDataManager.AddDrink(ColdDataManager.WriteParameters());

            Dictionary<string, AbstractDrink> drinks = ColdDataManager.ReturnDrinksDict();

            List<Orange> oranges = new List<Orange>() { };

            DrinksMachinesManager MachinesManager = new DrinksMachinesManager()
            {
                Machines = new List<AbstractMachine>()
                {
                    new ColdDrinksMachine
                    ( "Артурка", "Дыбенко", drinks),

                    new ColdDrinksMachine
                    ( "Лупа", "бенко", drinks),

                    new CoffeeMachine
                    ( "Максем", "Пионерская", 100, 100, 100, 100, hotDrinks ),

                    new CoffeeMachine
                    ( "Боба", "Автово", 10, 10, 1, 1, hotDrinks ),

                    new JuiceMachine
                    ( "ЕГОРКА", "Спасская" )
                },

                ErrorsWriter = new ErrorsDataManager("Data/MachineErrors")
            };
            
            while (true)
            {
                MachinesManager.PrintInfo();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                
                MachinesManager.RunMachines();
                
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
