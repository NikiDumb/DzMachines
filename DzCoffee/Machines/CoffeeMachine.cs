using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    public class CoffeeMachine
    {
        public double Water { get; private set; }

        public double CoffeePowder { get; private set; }

        public double Milk { get; private set; }

        public int Sugar { get; private set; }

        private Dictionary<string, HotDrink> _hotDrinks;

        private double _money;

        public CoffeeMachine(double water, double coffeePowder, double milk, int sugar, Dictionary<string, HotDrink> hotDrinks)
        {
            Water = water;
            CoffeePowder = coffeePowder;
            Milk = milk;
            Sugar = sugar;
            _hotDrinks = hotDrinks;
            _money = 0;
        }

        public void GetHotDrink()
        {
            PrintHotDrinksList();

            string nameOfChoicedHotDrink = ChooseHotDrink();

            ValidateHotDrink(nameOfChoicedHotDrink);

            double enteredMoney = EnterMoney();

            PayForHotDrink(nameOfChoicedHotDrink, enteredMoney);

            MakeHotDrink(nameOfChoicedHotDrink);
        }

        private void PrintHotDrinksList()
        {
            Console.WriteLine("Меню горячих напитков");

            foreach (HotDrink hotDrink in _hotDrinks.Values)
            {
                hotDrink.PrintDrink();
            }

            Console.WriteLine("Выбери напиток, написав его название");
        }

        private string ChooseHotDrink()
        {
            string nameOfChoicedHotDrink = Console.ReadLine();

            return nameOfChoicedHotDrink;
        }

        private void ValidateHotDrink(string drinkName)
        {
            if (!_hotDrinks.ContainsKey(drinkName))
            {
                throw new Exception("Неверный выбор напитка");
            }
        }

        private double EnterMoney()
        {
            Console.WriteLine("Карту с баблом запихивай и спишем деняк сколько скажешь");

            double money = Convert.ToDouble(Console.ReadLine());

            return money;
        }

        private void PayForHotDrink(string drinkName, double money)
        {
            if (money < _hotDrinks[drinkName].Price)
            {
                throw new Exception("Ты слишком бедный");
            }
            else
            {
                _money += money;
            }
        }

        private void MakeHotDrink(string drinkName)
        {
            HotDrink crntDrink = _hotDrinks[drinkName];
            if (Water - crntDrink.WaterNeeded < 0
                || CoffeePowder - crntDrink.CoffeePowderNeeded < 0
                || Milk - crntDrink.MilkNeeded < 0
                || Sugar - crntDrink.SugarNeeded < 0)
            {
                throw new Exception($"Аппарат не приготовит тебе {crntDrink.Name}");
            }
            else
            {
                Water -= crntDrink.WaterNeeded;
                CoffeePowder -= crntDrink.CoffeePowderNeeded;
                Milk -= crntDrink.MilkNeeded;
                Sugar -= crntDrink.SugarNeeded;

                Console.WriteLine($"Ваш {crntDrink.Name} готов!!!!");
                Console.WriteLine();
            }
        }
    }
}
