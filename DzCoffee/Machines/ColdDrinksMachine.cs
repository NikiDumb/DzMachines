﻿using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    public class ColdDrinksMachine : AbstractMachine
    {
        public Dictionary<string, int> CountsOfColdDrinks { get; set; }

        private Dictionary<string, ColdDrink> _coldDrinks;

        public double Money { get; set; }

        public ColdDrinksMachine(string name, string address, Dictionary<string, AbstractDrink> drinks)
            : base(name, address)
        {
            _coldDrinks = _CreateColdDrinksDict(drinks);
            Money = 0;
        }

        public override void GetDrink()
        {
            PrintColdDrinksList();

            string nameOfChoicedColdDrink = ChooseColdDrink();

            ValidateColdDrink(nameOfChoicedColdDrink);

            double enteredMoney = EnterMoney();

            PayForColdDrink(nameOfChoicedColdDrink, enteredMoney);

            MakeColdDrink(nameOfChoicedColdDrink);
        }

        public override void ReloadMachineStocks()
        {
            for (int i = _coldDrinks.Count - 1; i >= 0; i--)
            {
                KeyValuePair<string, ColdDrink> drink = _coldDrinks.ElementAt(i);

                if (drink.Value.Count == 0)
                {
                    drink.Value.Count = 6;
                }
            }
        }

        private Dictionary<string, ColdDrink> _CreateColdDrinksDict(Dictionary<string, AbstractDrink> drinks)
        {
            Dictionary<string, ColdDrink> coldDrinks = new Dictionary<string, ColdDrink>();

            foreach (AbstractDrink drink in drinks.Values)
            {
                coldDrinks.Add(drink.Name, new ColdDrink(drink.Name, drink.Price, 0));
            }
            
            return coldDrinks;
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
                Console.WriteLine("Неверный выбор напитка");
                throw new Exception("");
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
                Console.WriteLine("Ты слишком бедный");
                throw new Exception("");
            }
            else
            {
                Money += money;
            }
        }

        private void MakeColdDrink(string drinkName)
        {
            ColdDrink crntDrink = _coldDrinks[drinkName];
            if (crntDrink.Count < 1)
            {
                isBroken = true;

                Console.WriteLine($"Аппарат не выдаст тебе {crntDrink.Name}");
                throw new Exception($"Автомат газировок {Name} {Address}! Беда: {crntDrink.Name} кончился!!");
            }
            else
            {
                crntDrink.Count -= 1;

                Console.WriteLine($"Ваш {crntDrink.Name} выдан!!!!");
                Console.WriteLine();
            }
        }
    }
}

