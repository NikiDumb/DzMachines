using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    internal class ColdDrinksMachine
    {
        private Dictionary<string, ColdDrink> _coldDrinks;

        private double _money;

        public ColdDrinksMachine(Dictionary<string, ColdDrink> coldDrinks)
        {
            _coldDrinks = coldDrinks;
            _money = 0;
        }

        public void GetColdDrink()
        {
            PrintColdDrinksList();

            string nameOfChoicedColdDrink = ChooseColdDrink();

            ValidateColdDrink(nameOfChoicedColdDrink);

            double enteredMoney = EnterMoney();

            PayForColdDrink(nameOfChoicedColdDrink, enteredMoney);

            MakeColdDrink(nameOfChoicedColdDrink);
        }

        private void PrintColdDrinksList()
        {
            Console.WriteLine("Меню холодных напитков");

            foreach (ColdDrink coldDrink in _coldDrinks.Values)
            {
                coldDrink.PrintDrink();
            }

            Console.WriteLine("Выбери напиток, написав название");
        }

        private string ChooseColdDrink()
        {
            string nameOfChoicedColdDrink = Console.ReadLine();

            return nameOfChoicedColdDrink;
        }

        private void ValidateColdDrink(string drinkName)
        {
            if (!_coldDrinks.ContainsKey(drinkName))
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

        private void PayForColdDrink(string drinkName, double money)
        {
            if (money < _coldDrinks[drinkName].Price)
            {
                throw new Exception("Ты слишком бедный");
            }
            else
            {
                _money += money;
            }
        }

        private void MakeColdDrink(string drinkName)
        {
            if (_coldDrinks[drinkName].Count < 1)
            {
                throw new Exception($"Аппарат не выдаст тебе {_coldDrinks[drinkName].Name}");
            }
            else
            {
                _coldDrinks[drinkName].Count -= 1;

                Console.WriteLine($"Ваш {_coldDrinks[drinkName].Name} выдан!!!!");
                Console.WriteLine();
            }
        }
    }
}

