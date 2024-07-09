using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    public class CoffeeMachine
    {
        public double Water { get; private set; }

        public double CoffeePowder { get; private set; }

        public double Milk { get; private set; }

        public int Sugar { get; private set; }

        private List<HotDrink> _hotDrinks;

        private double _money;

        public CoffeeMachine(double water, double coffeePowder, double milk, int sugar, List<HotDrink> hotDrinks)
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

            int numOfChoicedHotDrink = ChoiceHotDrink();

            double enteredMoney = EnterMoney();

            PayForHotDrink(numOfChoicedHotDrink, enteredMoney);

            MakeHotDrink(numOfChoicedHotDrink);

            CompleteHotDrink(numOfChoicedHotDrink);
        }

        private void PrintHotDrinksList()
        {
            Console.WriteLine("Меню горячих напитков");

            for (int i = 0; i < _hotDrinks.Count; i++)
            {
                Console.WriteLine($"Напиток #{i + 1}");

                _hotDrinks[i].PrintDrink();
            }

            Console.WriteLine("Выбери напиток, написав циферку");
        }

        private int ChoiceHotDrink()
        {
            int numOfChoicedHotDrink = Convert.ToInt32(Console.ReadLine()) - 1;

            if (numOfChoicedHotDrink < 0
                || numOfChoicedHotDrink > _hotDrinks.Count - 1)
            {
                throw new Exception("Неверный выбор напитка");
            }
            else
            {
                return numOfChoicedHotDrink;
            }
        }

        private double EnterMoney()
        {
            Console.WriteLine("Карту с баблом запихивай и спишем деняк сколько скажешь");

            double money = Convert.ToDouble(Console.ReadLine());

            return money;
        }

        private void PayForHotDrink(int numOfHotDrink, double money)
        {
            if (money < _hotDrinks[numOfHotDrink].Price)
            {
                throw new Exception("Ты слишком бедный");
            }
            else
            {
                _money += money;
            }
        }

        private void MakeHotDrink(int numOfHotDrink)
        {
            if (Water - _hotDrinks[numOfHotDrink].WaterNeeded < 0
                || CoffeePowder - _hotDrinks[numOfHotDrink].CoffeePowderNeeded < 0
                || Milk - _hotDrinks[numOfHotDrink].MilkNeeded < 0
                || Sugar - _hotDrinks[numOfHotDrink].SugarNeeded < 0)
            {
                throw new Exception($"Аппарат не приготовит тебе {_hotDrinks[numOfHotDrink].Name}");
            }
            else
            {
                Water -= _hotDrinks[numOfHotDrink].WaterNeeded;
                CoffeePowder -= _hotDrinks[numOfHotDrink].CoffeePowderNeeded;
                Milk -= _hotDrinks[numOfHotDrink].MilkNeeded;
                Sugar -= _hotDrinks[numOfHotDrink].SugarNeeded;
            }
        }

        private void CompleteHotDrink(int numOfHotDrink)
        {
            Console.WriteLine($"Ваш {_hotDrinks[numOfHotDrink].Name} готов!!!!");
            Console.WriteLine();
        }
    }
}
