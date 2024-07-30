﻿using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    public class CoffeeMachine : AbstractMachine
    {
        public double Water { get; set; }

        public double CoffeePowder { get; set; }

        public double Milk { get; set; }

        public int Sugar { get; set; }

        private Dictionary<string, HotDrink> _hotDrinks;

        private double _money;

        public CoffeeMachine(string name, string address, double water, double coffeePowder, double milk,
            int sugar, Dictionary<string, HotDrink> hotDrinks)
            : base(name, address)
        {
            Water = water;
            CoffeePowder = coffeePowder;
            Milk = milk;
            Sugar = sugar;
            _hotDrinks = new Dictionary<string, HotDrink> (hotDrinks);
            _money = 0;
        }

        public override void GetDrink()
        {
            PrintHotDrinksList();

            string nameOfChoicedHotDrink = ChooseHotDrink();

            ValidateHotDrink(nameOfChoicedHotDrink);

            double enteredMoney = EnterMoney();

            PayForHotDrink(nameOfChoicedHotDrink, enteredMoney);

            MakeHotDrink(nameOfChoicedHotDrink);
        }

        public override void ReloadMachineStocks()
        {
            Water = 200;
            CoffeePowder = 200;
            Milk = 200;
            Sugar = 35;
        }

        private void PrintHotDrinksList()
        {
            Console.WriteLine("Меню горячих напитков");

            foreach (HotDrink hotDrink in _hotDrinks.Values)
            {
                Console.WriteLine(hotDrink);
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

        private void PayForHotDrink(string drinkName, double money)
        {
            if (money != _hotDrinks[drinkName].Price)
            {
                Console.WriteLine("Ты слишком бедный");
                throw new Exception("");
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
                isBroken = true;

                Console.WriteLine($"Аппарат не приготовит тебе {crntDrink.Name}");
                throw new Exception($"Автомат кофе {Name} {Address}! Беда: Напиток {crntDrink} кончился Кофе {CoffeePowder} Вода {Water} Молоко {Milk} Сахар {Sugar}");
            }
            else
            {
                Water -= crntDrink.WaterNeeded;
                CoffeePowder -= crntDrink.CoffeePowderNeeded;
                Milk -= crntDrink.MilkNeeded;
                Sugar -= crntDrink.SugarNeeded;

                Console.WriteLine($"Ваш {crntDrink} готов!!!!");
                Console.WriteLine();
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is CoffeeMachine machine &&
                   Name == machine.Name &&
                   Address == machine.Address &&
                   isBroken == machine.isBroken &&
                   Water == machine.Water &&
                   CoffeePowder == machine.CoffeePowder &&
                   Milk == machine.Milk &&
                   Sugar == machine.Sugar &&
                   _hotDrinks.OrderBy(kvp => kvp.Key).SequenceEqual(machine._hotDrinks.OrderBy(kvp => kvp.Key)) &&
                   _money == machine._money;
        }
    }
}
