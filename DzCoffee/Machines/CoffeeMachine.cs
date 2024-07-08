using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    public class CoffeeMachine
    {
        public double Water { get; private set; }

        public double CoffeePowder { get; private set; }

        public double Milk { get; private set; }

        public int Sugar { get; private set; }

        private List<HotDrink> _HotDrinks;

        private double _Money;

        public CoffeeMachine(double water, double coffeePowder, double milk, int sugar, List<HotDrink> hotDrinks)
        {
            Water = water;
            CoffeePowder = coffeePowder;
            Milk = milk;
            Sugar = sugar;
            _HotDrinks = hotDrinks;
            _Money = 0;
        }

        public void GetHotDrink()
        {
            PrintHotDrinksList();

            int numOfChoicedHotDrink = ChoiceHotDrink();

            double enteredMoney = EnterMoney();

            PayForHotDrink(numOfChoicedHotDrink, enteredMoney);

            MakeHotDrink(numOfChoicedHotDrink);

            CompleteHotDrink(numOfChoicedHotDrink);
        }

        private void PrintHotDrinksList()
        {
            Console.WriteLine("Меню горячих напитков");

            for (int i = 0; i < _HotDrinks.Count; i++)
            {
                Console.WriteLine($"Напиток #{i + 1}");

                _HotDrinks[i].PrintDrink();
            }

            Console.WriteLine("Выбери напиток, написав циферку");
        }

        private int ChoiceHotDrink()
        {
            int numOfChoicedHotDrink = Convert.ToInt32(Console.ReadLine()) - 1;

            if (numOfChoicedHotDrink < 0
                || numOfChoicedHotDrink > _HotDrinks.Count-1)
            {
                throw new Exception("Неверный выбор напитка");
            }

            return numOfChoicedHotDrink;
        }

        private double EnterMoney()
        {
            Console.WriteLine("Карту с баблом запихивай и спишем деняк сколько скажешь");

            double money = Convert.ToDouble(Console.ReadLine());

            return money;
        }

        private void PayForHotDrink(int numOfHotDrink, double money)
        {
            if (money < _HotDrinks[numOfHotDrink].Price)
            {
                throw new Exception("Ты слишком бедный");
            }

            _Money += money;
        }

        private void MakeHotDrink(int numOfHotDrink)
        {
            if (Water - _HotDrinks[numOfHotDrink].WaterNeeded < 0
                || CoffeePowder - _HotDrinks[numOfHotDrink].CoffeePowderNeeded < 0
                || Milk - _HotDrinks[numOfHotDrink].MilkNeeded < 0
                || Sugar - _HotDrinks[numOfHotDrink].SugarNeeded < 0)
            {
                throw new Exception($"Аппарат не приготовит тебе {_HotDrinks[numOfHotDrink].Name}");
            }

            Water -= _HotDrinks[numOfHotDrink].WaterNeeded;
            CoffeePowder -= _HotDrinks[numOfHotDrink].CoffeePowderNeeded;
            Milk -= _HotDrinks[numOfHotDrink].MilkNeeded;
            Sugar -= _HotDrinks[numOfHotDrink].SugarNeeded;
        }

        private void CompleteHotDrink(int numOfHotDrink)
        {
            Console.WriteLine($"Ваш {_HotDrinks[numOfHotDrink].Name} готов!!!!");
            Console.WriteLine();
        }
    }
}
