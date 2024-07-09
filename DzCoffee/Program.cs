using DzCoffee.Drinks;
using DzCoffee.Machines;

namespace DzCoffee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HotDrink> hotDrinks = new List<HotDrink>()
            { 
                new HotDrink("Кофеёк", 20, 20, 0, 0, 100),

                new HotDrink("Моча", 25, 25, 25, 25, 125),

                new HotDrink("Какао", 30, 30, 30, 0, 130),

                new HotDrink("Эспрессо", 50, 50, 0, 0, 200)
            };
            
            List<ColdDrink> coldDrinks = new List<ColdDrink>()
            {
                new ColdDrink("Добровый кола", 89, 5),

                new ColdDrink("Добровый палпи", 100, 7),

                new ColdDrink("Добровый орандж", 69, 2)
            };

            CoffeeMachine CoffeeMachineFirst = new CoffeeMachine(100, 100, 100, 100, hotDrinks);

            ColdDrinksMachine ColdDrinksMachineFirst = new ColdDrinksMachine(coldDrinks);

            while (true)
            {
                try
                {
                    CoffeeMachineFirst.GetHotDrink();
                    ColdDrinksMachineFirst.GetColdDrink();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Беда {e.Message}");
                }
            }
        }
    }
}
