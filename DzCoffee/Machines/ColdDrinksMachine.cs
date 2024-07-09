namespace DzCoffee.Machines
{
    internal class ColdDrinksMachine
    {
        private List<Drinks.ColdDrink> _coldDrinks;

        private double _money;

        public ColdDrinksMachine(List<Drinks.ColdDrink> coldDrinks)
        {
            _coldDrinks = coldDrinks;
            _money = 0;
        }

        public void GetColdDrink()
        {
            PrintColdDrinksList();

            int numOfChoicedColdDrink = ChoiceColdDrink();

            double enteredMoney = EnterMoney();

            PayForColdDrink(numOfChoicedColdDrink, enteredMoney);

            MakeColdDrink(numOfChoicedColdDrink);

            CompleteColdDrink(numOfChoicedColdDrink);
        }

        private void PrintColdDrinksList()
        {
            Console.WriteLine("Меню холодных напитков");

            for (int i = 0; i < _coldDrinks.Count; i++)
            {
                Console.WriteLine($"Напиток #{i + 1}");

                _coldDrinks[i].PrintDrink();
            }

            Console.WriteLine("Выбери напиток, написав циферку");
        }

        private int ChoiceColdDrink()
        {
            int numOfChoicedColdDrink = Convert.ToInt32(Console.ReadLine()) - 1;

            if (numOfChoicedColdDrink < 0
                || numOfChoicedColdDrink > _coldDrinks.Count - 1)
            {
                throw new Exception("Неверный выбор напитка");
            }
            else
            {
                return numOfChoicedColdDrink;
            }
        }

        private double EnterMoney()
        {
            Console.WriteLine("Карту с баблом запихивай и спишем деняк сколько скажешь");

            double money = Convert.ToDouble(Console.ReadLine());

            return money;
        }

        private void PayForColdDrink(int numOfColdDrink, double money)
        {
            if (money < _coldDrinks[numOfColdDrink].Price)
            {
                throw new Exception("Ты слишком бедный");
            }
            else
            {
                _money += money;
            }
        }

        private void MakeColdDrink(int numOfColdDrink)
        {
            if (_coldDrinks[numOfColdDrink].Count < 1)
            {
                throw new Exception($"Аппарат не выдаст тебе {_coldDrinks[numOfColdDrink].Name}");
            }
            else
            {
                _coldDrinks[numOfColdDrink].Count -= 1;
            }
        }

        private void CompleteColdDrink(int numOfColdDrink)
        {
            Console.WriteLine($"Ваш {_coldDrinks[numOfColdDrink].Name} выдан!!!!");
            Console.WriteLine();
        }
    }
}

