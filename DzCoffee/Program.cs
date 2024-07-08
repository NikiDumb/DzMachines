using DzCoffee.Drinks;
using DzCoffee.Machines;

namespace DzCoffee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HotDrink> drinksForCoffeeMachine = new List<HotDrink>();

            HotDrink coffee = new HotDrink("Кофеёк", 20, 20, 0, 0, 100);
            drinksForCoffeeMachine.Add(coffee);

            HotDrink mocha = new HotDrink("Моча", 25, 25, 25, 25, 125);
            drinksForCoffeeMachine.Add(mocha);

            HotDrink cacao = new HotDrink("Какао", 30, 30, 30, 0, 130);
            drinksForCoffeeMachine.Add(cacao);

            HotDrink espresso = new HotDrink("Эспрессо", 50, 50, 0, 0, 200);
            drinksForCoffeeMachine.Add(espresso);

            CoffeeMachine CoffeeMachineFirst = new CoffeeMachine(100, 100, 100, 100, drinksForCoffeeMachine);

            List<ColdDrink> coldDrinks = new List<ColdDrink>();

            ColdDrink cola = new ColdDrink("Добровый кола", 89, 5);
            coldDrinks.Add(cola);

            ColdDrink pulpy = new ColdDrink("Добровый палпи", 100, 7);
            coldDrinks.Add(pulpy);

            ColdDrink fanta = new ColdDrink("Добровый орандж", 69, 2);
            coldDrinks.Add(fanta);

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
